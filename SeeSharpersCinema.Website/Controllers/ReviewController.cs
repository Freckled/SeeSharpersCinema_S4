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

namespace SeeSharpersCinema.Website.Controllers
{
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
        public async Task<IActionResult> Post([Bind("MovieId,Title,Message,Rating")] Review review)
        {
            //var user = await GetCurrentUserAsync();


            review.IdentityUser = await _userManager.GetUserAsync(HttpContext.User);


            await reviewRepository.PostReview(review);

            return RedirectToAction("Index", "Home");
        }

    }
}
