using SeeSharpersCinema.Models.Film;
using SeeSharpersCinema.Models.Order;
using Xunit;

namespace SeeSharpersCinema.Tests
{
    public class TicketTests
    {
        [Fact]
        public void getTotalPrice()
        {
            // Assert
            Movie m1 = new Movie { Duration = 60, Technique = "2D" };
            Ticket t1 = new Ticket { Movie = m1 };

            Movie m2 = new Movie { Duration = 160, Technique = "3D" };
            Ticket t2 = new Ticket { Movie = m2 };

            // Act
            var result1 = t1.TotalPrice();
            var result2 = t2.TotalPrice();

            // Arrange
            Assert.Equal(8.5, result1);
            Assert.Equal(11.5, result2);
        }

    }
}
