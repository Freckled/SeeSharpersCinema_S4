using SeeSharpersCinema.Models.Film;
using Xunit;

namespace SeeSharpersCinema.Tests
{
    public class MovieTests
    {
        [Fact]
        public void CanChangeId()
        {
            // Arrange
            Movie m = new Movie { Id = 1 };

            // Act
            m.Id = 2;

            // Assert
            Assert.Equal(2, m.Id);
            Assert.True(m.Id.GetType() == typeof(long));
        }

        [Fact]
        public void CanChangeTitle()
        {
            // Arrange
            Movie m = new Movie { Title = "Test" };

            // Act
            m.Title = "NewName";

            // Assert
            Assert.Equal("NewName", m.Title);
            Assert.True(m.Title.GetType() == typeof(string));
        }

        [Fact]
        public void CanChangePosterUrl()
        {
            // Arrange
            Movie m = new Movie { PosterUrl = "https://www.nos.nl" };

            // Act
            m.PosterUrl = "https://www.nu.nl";

            // Assert
            Assert.Equal("https://www.nu.nl", m.PosterUrl);
            Assert.True(m.PosterUrl.GetType() == typeof(string));
        }

        [Fact]
        public void CanChangeDuration()
        {
            // Arrange
            Movie m = new Movie { Duration = 120 };

            // Act
            m.Duration = 130;

            // Assert
            Assert.Equal(130, m.Duration);
            Assert.True(m.Duration.GetType() == typeof(int));
        }

        [Fact]
        public void CanChangeLanguage()
        {
            // Arrange
            Movie m = new Movie { Language = "Original" };

            // Act
            m.Language = "Nederlands";

            // Assert
            Assert.Equal("Nederlands", m.Language);
            Assert.True(m.Language.GetType() == typeof(string));
        }

        [Fact]
        public void CanChangeTechnique()
        {
            // Arrange
            Movie m = new Movie { Technique = "2D" };

            // Act
            m.Technique = "3D";

            // Assert
            Assert.Equal("3D", m.Technique);
            Assert.True(m.Technique.GetType() == typeof(string));
        }

        [Fact]
        public void CanChangeDescription()
        {
            // Arrange
            Movie m = new Movie { Description = "Lorem Ipsum" };

            // Act
            m.Description = "Ipsum Lorem";

            // Assert
            Assert.Equal("Ipsum Lorem", m.Description);
            Assert.True(m.Description.GetType() == typeof(string));
        }

        [Fact]
        public void CanChangeViewIndication()
        {
            // Arrange
            Movie m = new Movie { ViewIndication = ViewIndication.Fourteen };

            // Act
            m.ViewIndication = ViewIndication.Six;

            // Assert
            Assert.Equal(ViewIndication.Six, m.ViewIndication);
            Assert.True(m.ViewIndication.GetType() == typeof(ViewIndication));
        }

        [Fact]
        public void CanChangeGenre()
        {
            // Arrange
            Movie m = new Movie { Genre = Genre.Action };

            // Act
            m.Genre = Genre.Animation;

            // Assert
            Assert.Equal(Genre.Animation, m.Genre);
            Assert.True(m.Genre.GetType() == typeof(Genre));
        }

        [Fact]
        public void CanChangeYear()
        {
            // Arrange
            Movie m = new Movie { Year = 2021 };

            // Act
            m.Year = 2020;

            // Assert
            Assert.Equal(2020, m.Year);
            Assert.True(m.Year.GetType() == typeof(int));
        }

        [Fact]
        public void CanChangeDirector()
        {
            // Arrange
            Movie m = new Movie { Director = "Stephen King" };

            // Act
            m.Director = "SeeSharpers";

            // Assert
            Assert.Equal("SeeSharpers", m.Director);
            Assert.True(m.Director.GetType() == typeof(string));
        }

        [Fact]
        public void CanChangeCountry()
        {
            // Arrange
            Movie m = new Movie { Country = "United States" };

            // Act
            m.Country = "United Kingdom";

            // Assert
            Assert.Equal("United Kingdom", m.Country);
            Assert.True(m.Country.GetType() == typeof(string));
        }

        [Fact]
        public void CanChangeIsLongMovie()
        {
            // Arrange
            Movie m = new Movie { Duration = 130 };

            // Assert
            Assert.True(m.IsLongMovie);
        }

        [Fact]
        public void CanChangeIsGenreChild()
        {
            // Arrange
            Movie m = new Movie { Genre = Genre.Children };
            Movie m1 = new Movie { Genre = Genre.Animation };

            // Assert
            Assert.True(m.IsGenreChild);
            Assert.False(m1.IsGenreChild);
        }

        [Fact]
        public void CanChangeIsThreeDimensional()
        {
            // Arrange
            Movie m = new Movie { Technique = "3D" };
            Movie m1 = new Movie { Technique = "2D" };

            // Assert
            Assert.True(m.IsThreeDimensional);
            Assert.False(m1.IsThreeDimensional);
        }

    }
}
