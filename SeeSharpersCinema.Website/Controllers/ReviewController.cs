using Microsoft.AspNetCore.Mvc;
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
        
                        
        public ReviewController(IPlayListRepository playListRepo)
        {
            this.repository = playListRepo;
        }

        public async Task<IActionResult> Index([FromRoute] long playListId)
        {
            var PlayListList = await repository.FindAllAsync();
            var PlayList = PlayListList.FirstOrDefault(p => p.Id == playListId);

            
            return View();
            //todo make VM return View(ReviewViewModel);
        }
    }
}
