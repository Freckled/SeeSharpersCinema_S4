using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Data.Models.Repository;
using SeeSharpersCinema.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Website.Controllers
{
    public class SeatController : Controller
    {

        private IPlayListRepository playListRepository;
        private IReservedSeatRepository seatRepository;

        public SeatController(IPlayListRepository playListRepository, IReservedSeatRepository seatRepository)
        {
            this.playListRepository = playListRepository;
            this.seatRepository = seatRepository;
        }

        [Route("Seat/Selector/{playListId}")]
        public async Task<IActionResult> Selector([FromRoute] long playListId)
        {

            var PlayListList = await playListRepository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.Id == playListId);

            //test all reserved seats
            var ReservedSeats = await seatRepository.FindAllByTimeSlotIdAsync(PlayList.TimeSlotId);

            var Seats = ReservedSeats.Select(i => i.SeatId).ToList();

            //ViewData["ReservedSeats"] = Seats;
            ViewData["RoomCapacity"] = ReservedSeats.FirstOrDefault().TimeSlot.Room.Capacity;
            ViewData["PlaylistId"] = PlayList.Id;

            return View(Seats);
        }

    }
}
