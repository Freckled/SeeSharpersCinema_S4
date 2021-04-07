using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Data.Infrastructure;
using SeeSharpersCinema.Data.Models.Program;
using SeeSharpersCinema.Data.Models.Repository;
using SeeSharpersCinema.Data.Models.ViewModel;
using SeeSharpersCinema.Data.Program;
using SeeSharpersCinema.Models.Program;
using SeeSharpersCinema.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SeeSharpersCinema.Website.Controllers
{
    public class SeatController : Controller
    {
        private IPlayListRepository playListRepository;
        private IReservedSeatRepository seatRepository;
        bool COVID = true;

        /// <summary>
        /// Constructor SeatController
        /// </summary>
        /// <param name="playListRepository">Constructor needs IPlayListRepository object</param>
        /// <param name="seatRepository">Constructor needs IReservedSeatRepository object</param>
        public SeatController(IPlayListRepository playListRepository, IReservedSeatRepository seatRepository)
        {
            this.playListRepository = playListRepository;
            this.seatRepository = seatRepository;
        }

        /// <summary>
        /// Selector creates SeatViewModel for the view
        /// </summary>
        /// <param name="playListId">The playListId given by the route.</param>
        /// <returns>SeatViewModel</returns>
        [Route("Seat/Selector/{playListId}")]
        public async Task<IActionResult> Selector([FromRoute] long playListId)
        {
            var PlayListList = await playListRepository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.Id == playListId);
            var ReservedSeats = await seatRepository.FindAllByTimeSlotIdAsync(PlayList.TimeSlotId);

            SeatViewModel SeatViewModel = new SeatViewModel();
            SeatViewModel.Movie = PlayList.Movie;
            SeatViewModel.TimeSlot = PlayList.TimeSlot;
            SeatViewModel.PlayListId = playListId;

            var Seats = ReservedSeats.ToList();
            var Seating = JSONSeatingHelper.JSONSeating(PlayList.TimeSlot.Room, Seats);
            SeatViewModel.SeatingArrangement = JSONSeatingHelper.JSONSeating(PlayList.TimeSlot.Room, Seats);

            return View(SeatViewModel);
        }

        /// <summary>
        /// takes post input as JSONstring and saves seats to db
        /// </summary>
        /// <param name="model">SeatViewModel with data from the reserveseatform.</param>
        /// <returns>Redirects to payment page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReserveSeats([Bind("SeatingArrangement, TimeSlotId, SeatAction")] SeatViewModel model)//todo remove testdata
        {
            var seatingArrangement = JsonSerializer.Deserialize<DeserializeRoot>(model.SeatingArrangement);

            List<ReservedSeat> seatList = new List<ReservedSeat>();
            seatingArrangement.selected.ForEach(s =>
            {
                ReservedSeat ReservedSeat = new ReservedSeat { SeatId = s.seatNumber, RowId = s.GridRowId, TimeSlotId = model.TimeSlotId, SeatState = SeatState.Reserved };
                seatList.Add(ReservedSeat);
            });
            var PlayListList = await playListRepository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.TimeSlotId == model.TimeSlotId);
            if (COVID)
            {
                seatList = await COVIDSeats(seatList);
            }                                        
            await seatRepository.ReserveSeats(seatList);
            return RedirectToAction("Pay", "Payment", new { id = PlayList.Id });                   
        }

        /// <summary>
        /// takes post input as JSONstring and removes seats from db
        /// </summary>
        /// <param name="model">SeatViewModel with data from the reserveseatform.</param>
        /// <returns>Redirects to seating page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveSeats([Bind("SeatingArrangement, TimeSlotId, SeatAction")] SeatViewModel model)//todo remove testdata
        {
            var PlayListList = await playListRepository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.TimeSlotId == model.TimeSlotId);

            if (model.SeatingArrangement != null) { 
                var seatingArrangement = JsonSerializer.Deserialize<DeserializeRoot>(model.SeatingArrangement);
            
                var ReservedSeats = await seatRepository.FindAllByTimeSlotIdAsync(model.TimeSlotId);
                var Seats = ReservedSeats.ToList();

                List<ReservedSeat> seatList = new List<ReservedSeat>();
                List<ReservedSeat> tempList = new List<ReservedSeat>();

                seatingArrangement.selected.ForEach(s =>
                {
                    ReservedSeat ReservedSeat = new ReservedSeat { SeatId = s.seatNumber, RowId = s.GridRowId, TimeSlotId = model.TimeSlotId, SeatState = SeatState.Reserved };
                    tempList.Add(ReservedSeat);
                });

                if (COVID)
                {
                    tempList = await COVIDSeats(tempList, false);
                }

                tempList.ForEach(s =>
                {
                    var tmpSeat = ReservedSeats
                                        .Where(r => s.RowId == r.RowId && s.SeatId == r.SeatId)
                                        .FirstOrDefault<ReservedSeat>();
                    if (tmpSeat != null)
                    {
                        seatList.Add(tmpSeat);
                    }
                });

                if (seatList.Count > 0)
                {
                    await seatRepository.RemoveSeats(seatList);
                }                
            }
            return RedirectToAction("Selector", "Seat", new { id = PlayList.Id });
        }























        /// <summary>
        /// Adds Seats to left and right in case of social distancing
        /// </summary>
        /// <param name="SeatList">A List of type Reserved Seat from user selected seats.</param>
        /// /// <param name="addSeat">boolean: Addseat = true, RemoveSeat=false.</param>
        /// <returns>A List of type Reserved Seat from user selected seats with disables seats on each side</returns>
        private async Task<List<ReservedSeat>> COVIDSeats(List<ReservedSeat> SeatList, bool addSeat = true)
        {
            var ReservedSeats = await seatRepository.FindAllByTimeSlotIdAsync(SeatList[0].TimeSlotId);
            List<ReservedSeat> tempSeatList = new List<ReservedSeat>();
            SeatList.ForEach(s => tempSeatList.Add(s));
            List<ReservedSeat> ReservedSeatList = new List<ReservedSeat>();
            ReservedSeatList = ReservedSeats.ToList();

            if (addSeat) { 
                SeatList.ForEach(s =>
                {
                    if ((ReservedSeatList.FindIndex(r => r.SeatId == (s.SeatId - 1) && r.RowId == s.RowId) == -1) && SeatList.FindIndex(f => f.SeatId == (s.SeatId - 1) && f.RowId == s.RowId) == -1)
                    {
                        ReservedSeat ReservedSeat = new ReservedSeat { SeatId = (s.SeatId - 1), RowId = s.RowId, TimeSlotId = s.TimeSlotId, SeatState = SeatState.Disabled };
                        tempSeatList.Add(ReservedSeat);
                    }

                    if ((ReservedSeatList.FindIndex(r => r.SeatId == (s.SeatId + 1) && r.RowId == s.RowId) == -1) && SeatList.FindIndex(f => f.SeatId == (s.SeatId + 1) && f.RowId == s.RowId) == -1)
                    {
                        ReservedSeat ReservedSeat = new ReservedSeat { SeatId = (s.SeatId + 1), RowId = s.RowId, TimeSlotId = s.TimeSlotId, SeatState = SeatState.Disabled };
                        tempSeatList.Add(ReservedSeat);
                    }
                });
            }
            else { 
                SeatList.ForEach(s =>
                {
                    if ((ReservedSeatList.FindIndex(r => r.SeatId == (s.SeatId - 1) && r.RowId == s.RowId) >= 0) && SeatList.FindIndex(f => f.SeatId == (s.SeatId - 1) && f.RowId == s.RowId) == -1)
                    {
                        ReservedSeat ReservedSeat = new ReservedSeat { SeatId = (s.SeatId - 1), RowId = s.RowId, TimeSlotId = s.TimeSlotId, SeatState = SeatState.Disabled };
                        tempSeatList.Add(ReservedSeat);
                    }

                    if ((ReservedSeatList.FindIndex(r => r.SeatId == (s.SeatId + 1) && r.RowId == s.RowId) >= 0) && SeatList.FindIndex(f => f.SeatId == (s.SeatId + 1) && f.RowId == s.RowId) == -1)
                    {
                        ReservedSeat ReservedSeat = new ReservedSeat { SeatId = (s.SeatId + 1), RowId = s.RowId, TimeSlotId = s.TimeSlotId, SeatState = SeatState.Disabled };
                        tempSeatList.Add(ReservedSeat);
                    }
                });
            }
            return tempSeatList;

        }

    }
}
