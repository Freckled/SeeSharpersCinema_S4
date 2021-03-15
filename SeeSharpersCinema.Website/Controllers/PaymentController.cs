using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Models.Order;
using Mollie.Api.Client;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment.Response;
using SeeSharpersCinema.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeeSharpersCinema.Models.Repository;
using SeeSharpersCinema.Models.Payment;

namespace SeeSharpersCinema.Website.Controllers
{

    public class PaymentController : Controller
    {
        IPaymentClient paymentClient = new PaymentClient("test_rWeMRKpke8RHJFezCqenNyJmHtQry8");
        PaymentRequest paymentRequest = new PaymentRequest()
        {
            Amount = new Amount(Currency.EUR, 100.00m),
            Description = "Test payment of the example project",
            RedirectUrl = "http://google.com",
            Method = Mollie.Api.Models.Payment.PaymentMethod.Ideal // instead of "Ideal"
        };
        /*        PaymentResponse paymentResponse = await paymentClient.CreatePaymentAsync(paymentRequest);
        */
        private IMovieRepository repository;
        public PaymentController(IMovieRepository repository)
        {
            this.repository = repository;
        }

        [Route("Payment/Pay")]
        public IActionResult Index([FromRoute] long movieId)
        {
            return View();
        }

        /*        public IActionResult Pay()
                {
                    SeeSharpersCinema.Models.EmailService emailService = new SeeSharpersCinema.Models.EmailService();
                    emailService.email_send();
                    return RedirectToAction("Overview", "Playlist");
                }*/
    }
}