using SeeSharpersCinema.Infrastructure;
using System;
using Xunit;

namespace SeeSharpersCinema.Tests
{
    /// <summary>
    /// Tests for the DateHelper Class
    /// </summary>
    public class DateHelperTests
    {
        /// <summary>
        /// Check if the Day returned is type of String
        /// </summary>
        [Fact]
        public void GetDayIsString()
        {
            // Arrange
            string sut = DateHelper.GetDay();

            // Assert
            Assert.IsType<string>(sut);
        }

        /// <summary>
        /// Check if the returned Day is really equal to Today
        /// </summary>
        [Fact]
        public void GetCurrentDayOfWeek()
        {
            // Arrange
            DayOfWeek today = DateTime.Today.DayOfWeek;
            string sut = DateHelper.GetDay();

            // Assert
            Assert.Equal(sut, today.ToString());
        }

        /// <summary>
        /// Check is the String to DateTime function returns the correct DateTime
        /// </summary>
        [Fact]
        public void CheckStringToDateTime()
        {
            // Arrange
            string Date = "1985-10-05";

            // Act
            DateTime sut = DateHelper.StringToDateTime(Date);

            // Assert
            Assert.IsType<DateTime>(sut);
            Assert.Equal(sut, new DateTime(1985, 10, 05, 00, 00, 00));
        }

        /// <summary>
        /// Check if the date returned is next Thursday
        /// </summary>
        [Fact]
        public void GetNextThursday()
        {
            // Arrange
            DateTime today = DateTime.Now.Date;
            int daysUntilThursday = ((int)DayOfWeek.Thursday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextThursday = today.AddDays(daysUntilThursday);

            // Arrange
            DateTime sut = DateHelper.GetNextThursday();

            // Assert
            Assert.IsType<DateTime>(sut);
            Assert.Equal(sut, nextThursday);
        }
    }
}
