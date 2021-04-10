using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Models.Repository;
using System.Threading.Tasks;

namespace SeeSharpersCinema.TouchScreen.Controllers
{
    public class PaymentController : Controller
    {
        private IMovieRepository repository;

        /// <summary>
        /// PaymentController constructor
        /// </summary>
        /// <param name="repository">Constructor needs IMovieRepository object</param>
        public PaymentController(IMovieRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get the view Index
        /// </summary>
        /// <param name="movieId">Method needs a parameter of type long</param>
        /// <returns>Ticket view of a specific movie by its id</returns>
        [Route("Ticket/Selector/Payment")]
        public async Task<IActionResult> IndexAsync(long movieId)
        {
            if (movieId == 0) 
            { 
                return NotFound(); 
            }

            var movie = await repository.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null) 
            { 
                return NotFound(); 
            }

            return View(movie);
        }

        /// <summary>
        /// Get the view Pay and call the email_send method of Emailservice class to send a QR code
        /// </summary>
        /// <returns>A redirect action to the view Overview from the PlayList controller</returns>
        public IActionResult Pay()
        {
            SeeSharpersCinema.Models.EmailService emailService = new SeeSharpersCinema.Models.EmailService();
            emailService.email_send();
            return RedirectToAction("Overview", "Playlist");
        }
    }
}