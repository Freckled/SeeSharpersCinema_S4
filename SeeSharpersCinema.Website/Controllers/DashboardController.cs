using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Data.Models.Repository;
using SeeSharpersCinema.Data.Models.ViewModel;
using SeeSharpersCinema.Infrastructure;
using SeeSharpersCinema.Models;
using SeeSharpersCinema.Models.Film;
using SeeSharpersCinema.Models.Program;
using SeeSharpersCinema.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Website.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class DashboardController : Controller
    {
        private IPlayListRepository playListRepository;
        private IMovieRepository movieRepository;
        private ITimeSlotRepository timeSlotRepository;

        /// <summary>
        /// DashboardController constructor
        /// </summary>
        public DashboardController(IPlayListRepository playListRepository, IMovieRepository movieRepository, ITimeSlotRepository timeSlotRepository)
        {
            this.playListRepository = playListRepository;
            this.movieRepository = movieRepository;
            this.timeSlotRepository = timeSlotRepository;
        }

        /// <summary>
        /// Week action for the week view
        /// </summary>
        /// <returns>The view with movie playlist of the week page</returns>
        public async Task<IActionResult> WeekAsync()
        {
            var playlist = await playListRepository.FindBetweenDatesAsync(DateTime.Now.Date, DateHelper.GetNextThursday());
            return View(playlist);
        }


        [HttpGet]
        [Route("Dashboard/Edit")]
        public async Task<IActionResult> EditMovie(long? id)
        {
            //change repos later
            if (id == null)
            {
                //return NotFound();
                id = 2;
            }
            var PlayListList = await playListRepository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.Id == id);

            if (PlayList == null)
            {
                return NotFound();
            }

            return View(PlayList.Movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Dashboard/Edit")]
        public async Task<IActionResult> EditMovie([Bind("Id,Title,PosterUrl,Duration,Cast,Director,Country,Language,Technique,Description,ViewIndication,Genre,Year")] Movie movie)
        {
            await movieRepository.UpdateMovieDetailsAsync(movie);
            return RedirectToAction("Edit", "Dashboard", new { id = movie.Id });
        }


        [HttpGet]
        [Route("Dashboard/Add")]
        public IActionResult AddMovie()
        {
            return View();
        }


        [HttpPost]
        [Route("Dashboard/Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMovie([Bind("Title,PosterUrl,Duration,Cast,Director,Country,Language,Technique,Description,ViewIndication,Genre,Year")] Movie movie)
        {
            await movieRepository.AddMovieAsync(movie);
            return RedirectToAction("Week", "Dashboard");
            //add movie overview redirect
        }

        [HttpGet]
        //[Route("Dashboard/PlayList/{movieId}")]
        public async Task<IActionResult> Movies()
        {
            var movies = await movieRepository.FindAllAsync();
            return View(movies);
        }


        [HttpGet]
        [Route("Dashboard/PlayList/{movieId}")]
        public async Task<IActionResult> EditPlayList(long movieId)
        {
            EditPlayListViewModel viewModel = new EditPlayListViewModel();

            var playList = await playListRepository.FindByMovieID(movieId);
            var playListList = playList.ToList();

            playListList.ForEach(p =>
            {
                viewModel.PlayLists.Add(p);
            });


            return View(viewModel);
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTimeSlots(EditPlayListViewModel model)
        {
            List<TimeSlot> editTimeSlotList = new List<TimeSlot>();

            var playListId = model.PlayLists.First().Id;
            model.PlayLists.ForEach(async p => {                
                TimeSlot slot = new TimeSlot { Id = p.Id ,RoomId = p.TimeSlot.RoomId, SlotStart = p.TimeSlot.SlotStart, SlotEnd = p.TimeSlot.SlotEnd };
                editTimeSlotList.Add(slot);
            });
           
            await timeSlotRepository.UpdateTimeSlots(editTimeSlotList);

            return RedirectToAction("PlayList", "Dashboard",new { id = playListId });
            
        }

    }
}
