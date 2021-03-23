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

            var Seats = ReservedSeats.ToList();
            var Seating = JSONSeatingHelper.JSONSeating(PlayList.TimeSlot.Room, Seats);
            SeatViewModel.SeatingArrangement = JSONSeatingHelper.JSONSeating(PlayList.TimeSlot.Room, Seats);

            return View(SeatViewModel);
        }


        /// <summary>
        /// takes post input as JSONstring and saves seats to db
        /// </summary>
        /// <param name="Seatstring">The JSON string given back from the form in the Seat/Selector.</param>
        /// <param name="TimeSlotId">The id corresponding to a specific TimeSlot. This is given back from the form in the Seat/Selector.</param>
        /// <returns>SeatViewModel</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReserveSeats(string Seatstring, long TimeSlotId)//todo remove testdata
        {
            var SeatingArrangement = JsonSerializer.Deserialize<DeserializeRoot>(Seatstring);

            List<ReservedSeat> SeatList = new List<ReservedSeat>();
            SeatingArrangement.selected.ForEach(s =>
            {
                ReservedSeat ReservedSeat = new ReservedSeat { SeatId = s.seatNumber, RowId = s.GridRowId, TimeSlotId = TimeSlotId, SeatState = SeatState.Reserved };
                SeatList.Add(ReservedSeat);
            });

            if (COVID)
            {
                SeatList = await COVIDSeats(SeatList);
            }
            await seatRepository.ReserveSeats(SeatList);
            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// Adds Seats to left and right in case of social distancing
        /// </summary>
        /// <param name="SeatList">A List of type Reserved Seat from user selected seats.</param>
        /// <returns>A List of type Reserved Seat from user selected seats with disables seats on each side</returns>
        private async Task<List<ReservedSeat>> COVIDSeats(List<ReservedSeat> SeatList)
        {
            var ReservedSeats = await seatRepository.FindAllByTimeSlotIdAsync(SeatList[0].TimeSlotId);
            List<ReservedSeat> tempSeatList = new List<ReservedSeat>();
            SeatList.ForEach(s => tempSeatList.Add(s));

            SeatList.ForEach(s =>
            {
                if ((ReservedSeats.ToList().FindIndex(r => r.SeatId == (s.SeatId - 1)) >= 0) && SeatList.FindIndex(f => f.SeatId == s.SeatId - 1) == -1)
                {
                    ReservedSeat ReservedSeat = new ReservedSeat { SeatId = (s.SeatId - 1), RowId = s.RowId, TimeSlotId = s.TimeSlotId, SeatState = SeatState.Disabled };
                    tempSeatList.Add(ReservedSeat);
                }

                if ((ReservedSeats.ToList().FindIndex(r => r.SeatId == (s.SeatId + 1)) >= 0) && SeatList.FindIndex(f => f.SeatId == s.SeatId + 1) == -1)
                {
                    ReservedSeat ReservedSeat = new ReservedSeat { SeatId = (s.SeatId + 1), RowId = s.RowId, TimeSlotId = s.TimeSlotId, SeatState = SeatState.Disabled };
                    tempSeatList.Add(ReservedSeat);
                }
            });

            return tempSeatList;

        }

    }
}
