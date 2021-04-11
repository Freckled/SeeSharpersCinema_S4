using Microsoft.AspNetCore.Authorization;
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
                seatList = await new SeatHelper(seatRepository,seatList).AddCOVIDSeats();
            }
            await seatRepository.ReserveSeats(seatList);
            return RedirectToAction("Pay", "Payment", new { id = PlayList.Id });
        }

        /// <summary>
        /// takes post input as JSONstring and removes seats from db
        /// </summary>
        /// <param name="model">SeatViewModel with data from the reserveseatform.</param>
        /// <returns>Redirects to seating page</returns>
        [Authorize(Roles = "Desk")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveSeats([Bind("SeatingArrangement, TimeSlotId, SeatAction")] SeatViewModel model)//todo remove testdata
        {
            var PlayListList = await playListRepository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.TimeSlotId == model.TimeSlotId);

            if (model.SeatingArrangement != null)
            {
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
                    tempList = await new SeatHelper(seatRepository, tempList).RemoveCOVIDSeats();
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
    }
}
