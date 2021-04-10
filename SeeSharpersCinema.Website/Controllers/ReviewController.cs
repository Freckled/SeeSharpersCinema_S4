using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Data.Models.Film;
using SeeSharpersCinema.Data.Models.Repository;
using SeeSharpersCinema.Data.Models.ViewModel;
using SeeSharpersCinema.Models.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Website.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {

        private IPlayListRepository playListRepository;
        private IReviewRepository reviewRepository;
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Constructor ReviewController
        /// </summary>
        /// <param name="playListRepository">Constructor needs IPlayListRepository object</param>
        /// <param name="userManager">Constructor needs UserManager<IdentityUser> object</param>
        /// <param name="reviewRepository">Constructor needs IReviewRepository object</param>
        public ReviewController(IPlayListRepository playListRepo, UserManager<IdentityUser> userManager, IReviewRepository reviewRepository)
        {
            this.playListRepository = playListRepo;
            this._userManager = userManager;
            this.reviewRepository = reviewRepository;

        }

        /// <summary>
        /// Returns the Post View for writing reviews
        /// </summary>
        /// <param name="playListId">PlaylistId to determine which movie to write review for</param>
        [HttpGet]
        [Route("Review/Post/{playListId}")]
        public async Task<IActionResult> Post([FromRoute] long playListId)
        {
            var PlayListList = await playListRepository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.Id == playListId);

            ReviewViewModel model = new ReviewViewModel();
            model.Movie = PlayList.Movie;

            return View(model);
        }

        /// <summary>
        /// Takes the post form and stores the review
        /// </summary>
        /// <param name="playListId">PlaylistId to determine which movie to write review for</param>
        /// <param name="review">Review object from the form with details for the review</param>
        [HttpPost]
        [Route("Review/Post/{playListId}")]
        public async Task<IActionResult> Post([FromRoute] long playListId, [Bind("MovieId,Title,Message,Rating")] Review review)
        {
            review.IdentityUser = await _userManager.GetUserAsync(HttpContext.User);
            review.Date = DateTime.UtcNow;

            await reviewRepository.PostReview(review);

            return RedirectToAction("Details", "Home", new { id = playListId });
        }

    }
}
