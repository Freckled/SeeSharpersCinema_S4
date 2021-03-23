using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Models.Order;
/*using Mollie.Api.Client;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment.Response;*/
using SeeSharpersCinema.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeeSharpersCinema.Models.Repository;
using SeeSharpersCinema.Models.Payment;
using Microsoft.EntityFrameworkCore;

namespace SeeSharpersCinema.Website.Controllers
{

    public class PaymentController : Controller
    {
        Movie mov;
        //IPaymentClient paymentClient = new PaymentClient("test_rWeMRKpke8RHJFezCqenNyJmHtQry8");
        //PaymentRequest paymentRequest = new PaymentRequest()
        //{
        // Amount = new Amount(Currency.EUR, 100.00m),
        // Description = "Test payment of the example project",
        // RedirectUrl = "http://google.com",
        //  Method = Mollie.Api.Models.Payment.PaymentMethod.Ideal // instead of "Ideal"
        //};
        /*        PaymentResponse paymentResponse = await paymentClient.CreatePaymentAsync(paymentRequest);
        */

        private IPlayListRepository repository;
        public PaymentController(IPlayListRepository repo)
        {
            repository = repo;
        }

        [Route("Payment/Pay")]

        public async Task<IActionResult> IndexAsync(long movieId)
        {
            if (movieId == 0)
            {
                return NotFound();
            }

            var movie = await repository.Movies
                .FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }
            mov = movie;
            return View(movie);
        }
        public async Task<IActionResult> Index()
        {
            var movieWeek = await repository.FindBetweenDatesAsync(DateTime.Now.Date, GetNextThursday());
            if (movieWeek == null)
            {
                return NotFound();
            }
            return View(movieWeek);
        }
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

        public DateTime GetNextThursday()
        {
            DateTime today = DateTime.Now.Date;
            //Voorbeeld voor vrijdag: 4 - 5 + 7 = 6 dagen tot donderdag. mooie uitleg: https://stackoverflow.com/questions/6346119/datetime-get-next-tuesday
            int daysUntilThursday = ((int)DayOfWeek.Thursday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextThursday = today.AddDays(daysUntilThursday);
            return nextThursday;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MolliePayment()
        {
            SeeSharpersCinema.Models.EmailService emailService = new SeeSharpersCinema.Models.EmailService();
            emailService.email_send();
            return View();
        }
    }
}

