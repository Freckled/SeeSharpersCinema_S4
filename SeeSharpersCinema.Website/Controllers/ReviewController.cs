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

namespace SeeSharpersCinema.Website.Controllers
{
    public class ReviewController : Controller
    {

        private IPlayListRepository playListRepository;
        private IReviewRepository reviewRepository;
        private readonly UserManager<IdentityUser> userManager;

        //todo Authorize

        public ReviewController(IPlayListRepository playListRepo, UserManager<IdentityUser> userManager, IReviewRepository reviewRepository)
        {
            this.playListRepository = playListRepo;
            this.userManager = userManager;
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
        public async Task<IActionResult> Post(long id, [Bind("Movie,Message,Rating")] Review review)
        {
            var user = await GetCurrentUserAsync();
            review.UserId = user?.Id;

            await reviewRepository.PostReview(review);

            return RedirectToAction("Index", "Home");
        }

        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);


    }
}
