using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Data.Models.Film;
using SeeSharpersCinema.Data.Models.Repository;
using SeeSharpersCinema.Data.Models.ViewModel;
using SeeSharpersCinema.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SeeSharpersCinema.Website.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {

        private IPlayListRepository playListRepository;
        private IReviewRepository reviewRepository;
        private readonly UserManager<IdentityUser> _userManager;

        //todo Authorize

        public ReviewController(IPlayListRepository playListRepo, UserManager<IdentityUser> userManager, IReviewRepository reviewRepository)
        {
            this.playListRepository = playListRepo;
            this._userManager = userManager;
            this.reviewRepository = reviewRepository;

        }

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

        [HttpPost]
        [Route("Review/Post/{playListId}")]
        public async Task<IActionResult> Post([FromRoute] long playListId,[Bind("MovieId,Title,Message,Rating")] Review review)
        {
            review.IdentityUser = await _userManager.GetUserAsync(HttpContext.User);
            review.Date = DateTime.UtcNow;

            await reviewRepository.PostReview(review);

            return RedirectToAction("Details", "Home", new { id = playListId });
        }

    }
}
