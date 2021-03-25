using Moq;
using SeeSharpersCinema.Models.Film;
using SeeSharpersCinema.Models.Repository;
using SeeSharpersCinema.Models.ViewModel;
using SeeSharpersCinema.TouchScreen.Controllers;
using System.Linq;
using Xunit;

namespace SeeSharpersCinema.IntegrationTests
{
    public class MovieControllerTests
    {
        [Fact]
        public void UsableMovieRepo()
        {
            // Arrange
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns((new Movie[]
            {
                new Movie { Id = 1, Title = "Title1"},
                new Movie { Id = 2, Title = "Title2"},
                new Movie { Id = 3, Title = "Title3"},
            }).AsQueryable<Movie>());

            MoviesController controller = new MoviesController(mock.Object);

            // Act
            MovieListViewModel result =
                controller.Overview().ViewData.Model as MovieListViewModel;

            // Assert
            Movie[] movieArray = result.Movies.ToArray();
            Assert.True(movieArray.Length == 3);
            Assert.Equal("Title1", movieArray[0].Title);
            Assert.Equal("Title2", movieArray[1].Title);
            Assert.Equal("Title3", movieArray[2].Title);
        }
    }
}
