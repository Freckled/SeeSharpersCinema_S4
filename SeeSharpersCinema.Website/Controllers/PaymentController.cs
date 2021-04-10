using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using SeeSharpersCinema.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace SeeSharpersCinema.Website.Controllers
{

    public class PaymentController : Controller
    {
        private IPlayListRepository repository;
        public PaymentController(IPlayListRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Open payment overview
        /// </summary>
        /// <param name="movieId">Id used to select correct PlayList object</param>
        /// <returns>Payment View</returns>
        [Route("Payment/Pay/{movieId}")]
        public async Task<IActionResult> IndexAsync([FromRoute] long? movieId)
        {
            if (movieId == null)
            {
                return NotFound();
            }
            var PlayListList = await repository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.Id == movieId);

            if (PlayList == null)
            {
                return NotFound();
            }

            return View(PlayList);
        }

        /// <summary>
        /// Movies per week
        /// </summary>
        /// <returns>Return view</returns>
        public async Task<IActionResult> Index()
        {
            var movieWeek = await repository.FindBetweenDatesAsync(DateTime.Now.Date, GetNextThursday());
            if (movieWeek == null)
            {
                return NotFound();
            }
            return View(movieWeek);
        }

        /// <summary>
        /// Get datetime for next thursday
        /// </summary>
        /// <returns>DateTime for next thursday</returns>
        public DateTime GetNextThursday()
        {
            DateTime today = DateTime.Now.Date;
            int daysUntilThursday = ((int)DayOfWeek.Thursday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextThursday = today.AddDays(daysUntilThursday);
            return nextThursday;
        }

        /// <summary>
        /// Go to Privacy View
        /// </summary>
        /// <returns>Privacy View</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Sends email to customer with QR code
        /// </summary>
        /// <returns>Payment View</returns>
        public IActionResult MolliePayment()
        {
            SeeSharpersCinema.Models.EmailService emailService = new SeeSharpersCinema.Models.EmailService();
            emailService.email_send();
            return View();
        }
    }
}

