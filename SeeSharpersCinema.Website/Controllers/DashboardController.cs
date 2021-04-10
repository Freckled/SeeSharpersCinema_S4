using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Infrastructure;
using SeeSharpersCinema.Models.Film;
using SeeSharpersCinema.Models.Program;
using SeeSharpersCinema.Models.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Website.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class DashboardController : Controller
    {
        private IPlayListRepository playListRepository;
        private IMovieRepository movieRepository;

        /// <summary>
        /// DashboardController constructor
        /// </summary>
        public DashboardController(IPlayListRepository playListRepository, IMovieRepository movieRepository)
        {
            this.playListRepository = playListRepository;
            this.movieRepository = movieRepository;
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

        /// <summary>
        /// Shows the all the movies
        /// </summary>
        /// <returns>The view with movies</returns>
        [HttpGet]
        [Route("Dashboard/Edit/{movieId}")]
        public async Task<IActionResult> EditMovie(long movieId)
        {
            //change repos later

            var PlayListList = await playListRepository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.Id == movieId);

            if (PlayList == null)
            {
                return NotFound();
            }

            return View(PlayList.Movie);
        }

        /// <summary>
        /// Edits movie info for a movie
        /// </summary>
        /// <returns>The view of the movie, edited</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Dashboard/Edit/{movieId}")]
        public async Task<IActionResult> EditMovie(Movie movie)
        {
            await movieRepository.UpdateMovieDetailsAsync(movie);
            return RedirectToAction("Edit", "Dashboard", new { id = movie.Id });
        }


        /// <summary>
        /// Gets the view for adding a movie
        /// </summary>
        /// <returns>The view of the movie add view</returns>
        [HttpGet]
        [Route("Dashboard/Add")]
        public IActionResult AddMovie()
        {
            return View();
        }

        /// <summary>
        /// Adds a new movie and about the movie
        /// </summary>
        /// <returns>Redirects to movie view after adding movie</returns>
        [HttpPost]
        [Route("Dashboard/Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMovie([Bind("Title,PosterUrl,Duration,Cast,Director,Country,Language,Technique,Description,ViewIndication,Genre,Year")] Movie movie)
        {
            await movieRepository.AddMovieAsync(movie);
            return RedirectToAction("Movies", "Dashboard");
        }

        /// <summary>
        /// Gets all movies and calls the movie view
        /// </summary>
        /// <returns>Shows the movie View</returns>
        [HttpGet]
        //[Route("Dashboard/PlayList/{movieId}")]
        public async Task<IActionResult> Movies()
        {
            var movies = await movieRepository.FindAllAsync();
            return View(movies);
        }
    }
}
