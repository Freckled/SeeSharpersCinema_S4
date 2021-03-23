using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Data.Models.ViewModel;
using SeeSharpersCinema.Infrastructure;
using SeeSharpersCinema.Models.Repository;
using SeeSharpersCinema.Models.Website;
using System;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Website.Controllers
{
    public class HomeController : Controller
    {

        private IPlayListRepository repository;

        private INoticeRepository noticeRepository;

        /// <summary>
        /// Constructor HomeController
        /// </summary>
        /// <param name="repo">Constructor needs IPlayListRepository object</param>
        /// <param name="noticeRepo">Constructor needs INoticeRepository object</param>
        public HomeController(IPlayListRepository repo, INoticeRepository noticeRepo)
        {
            repository = repo;
            noticeRepository = noticeRepo;
        }

        /// <summary>
        /// Read detailed view for specific Movie based on MovieId or if an incorect movieId is provided; return NotFound
        /// </summary>
        /// <param name="id">MovieId used to read specific Movie</param>
        /// <returns>NotFound view or specific details view</returns>
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await repository.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        /// <summary>
        /// Get the View Index for showing current movieweek
        /// </summary>
        /// <param name="uiTitle">Selection string: user input for title</param>
        /// <param name="uiDate">Selection string: user input string for date</param>
        /// <param name="uiGenre">Selection string: user input string for genre</param>
        /// <param name="uiViewIndication">Selection string: user input string for view indication</param>
        /// <returns>View of current movieweek with or without user selection</returns>
        public async Task<IActionResult> Index(string uiTitle, string uiDate, string uiGenre, string uiViewIndication)
        {
            // Get movies of current filmweek
            var movieWeek = await repository.FindBetweenDatesAsync(DateTime.Now.Date, DateHelper.GetNextThursday());
            // Get the notice where the Id equals 1
            Notice notice = await noticeRepository.Notices.FirstOrDefaultAsync(n => n.Id == 1);

            // Get movies of current filmweek with this title
            if (!String.IsNullOrEmpty(uiTitle))
            {
                movieWeek = await repository.FindByTitle(DateTime.Now.Date, DateHelper.GetNextThursday(), uiTitle);
            }

            // Get movies of this date
            if (!String.IsNullOrEmpty(uiDate))
            {
                DateTime newDate = DateHelper.StringToDateTime(uiDate);
                movieWeek = await repository.FindByDate(newDate);
            }

            // Get movies of current filmweek with this genre
            if (!String.IsNullOrEmpty(uiGenre))
            {
                movieWeek = await repository.FindByGenre(DateTime.Now.Date, DateHelper.GetNextThursday(), uiGenre);
            }

            // Get movies of current filmweek with this view indication
            if (!String.IsNullOrEmpty(uiViewIndication))
            {
                movieWeek = await repository.FindByViewIndication(DateTime.Now.Date, DateHelper.GetNextThursday(), uiViewIndication);
            }

            // Get movies of this date with this title
            if (!String.IsNullOrEmpty(uiTitle) && !String.IsNullOrEmpty(uiDate))
            {
                DateTime newDate = DateHelper.StringToDateTime(uiDate);
                movieWeek = await repository.FindByTitleAndDate(uiTitle, newDate);
            }

            // Get movies of this date with this genre
            if (!String.IsNullOrEmpty(uiDate) && !String.IsNullOrEmpty(uiGenre))
            {
                DateTime newDate = DateHelper.StringToDateTime(uiDate);
                movieWeek = await repository.FindByDateAndGenre(newDate, uiGenre);
            }

            // Get movies with this view indication of this date
            if (!String.IsNullOrEmpty(uiViewIndication) && !String.IsNullOrEmpty(uiDate))
            {
                DateTime newDate = DateHelper.StringToDateTime(uiDate);
                movieWeek = await repository.FindByViewIndication(DateTime.Now.Date, DateHelper.GetNextThursday(), uiViewIndication);
            }

            // Get movies with this view indication of this genre
            if (!String.IsNullOrEmpty(uiViewIndication) && !String.IsNullOrEmpty(uiGenre))
            {
                movieWeek = await repository.FindByViewIndicationAndGenre(DateTime.Now.Date, DateHelper.GetNextThursday(), uiViewIndication, uiGenre);
            }

            if (movieWeek == null)
            {
                return NotFound();
            }

            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Playlists = movieWeek;
            homeViewModel.Notices = notice;
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
