using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Infrastructure;
using SeeSharpersCinema.Models.Repository;
using System;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Website.Controllers
{   
    public class DashboardController : Controller
    {
        private IPlayListRepository repository;

        /// <summary>
        /// DashboardController constructor
        /// </summary>
        public DashboardController(IPlayListRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Week action for the week view
        /// </summary>
        /// <returns>The view with movie playlist of the week page</returns>
        public async Task<IActionResult> WeekAsync()
        {
            var playlist = await repository.FindBetweenDatesAsync(DateTime.Now.Date, DateHelper.GetNextThursday());
            return View(playlist);
        }
    }
}
