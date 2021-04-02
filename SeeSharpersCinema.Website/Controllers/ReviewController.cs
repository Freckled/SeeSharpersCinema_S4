using Microsoft.AspNetCore.Mvc;
using SeeSharpersCinema.Data.Models.Film;
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

        private IPlayListRepository repository;
        

        //todo Authorize
                        
        public ReviewController(IPlayListRepository playListRepo)
        {
            this.repository = playListRepo;
        }

        [Route("Review/Post/{playListId}")]
        public async Task<IActionResult> Write([FromRoute] long playListId)
        {
            var PlayListList = await repository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.Id == playListId);

            ReviewViewModel model = new ReviewViewModel();
            model.Movie = PlayList.Movie;
                        
            return View(model);
        }


        public async Task<IActionResult> Post(long id, [Bind("Id,Message,Rating")] Review review)
        {
            return View();
        }




    }
}
