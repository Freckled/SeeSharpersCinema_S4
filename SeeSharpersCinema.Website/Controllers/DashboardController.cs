using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeeSharpersCinema.Models.Repository;
using SeeSharpersCinema.Infrastructure;

namespace SeeSharpersCinema.Website.Controllers
{
    public class DashboardController : Controller
    {
        private IPlayListRepository repository;

        public DashboardController(IPlayListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> WeekAsync()
        {
            var playlist = await repository.FindBetweenDatesAsync(DateTime.Now.Date, DateHelper.GetNextThursday());
            return View(playlist);
        }
    }
}
