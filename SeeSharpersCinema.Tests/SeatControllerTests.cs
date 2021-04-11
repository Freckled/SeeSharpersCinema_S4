using Moq;
using SeeSharpersCinema.Data.Models.Repository;
using SeeSharpersCinema.Models.Repository;
using SeeSharpersCinema.Website.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Tests
{
    class SeatControllerTests
    {


        public void COVIDTest()
        {

            Mock<IPlayListRepository> playListRepository = new Mock<IPlayListRepository>();
            Mock<IReservedSeatRepository> seatRepository = new Mock<IReservedSeatRepository>();

            SeatController controller = new SeatController(playListRepository.Object, seatRepository.Object);

            controller.Cov

        }



    }
}
