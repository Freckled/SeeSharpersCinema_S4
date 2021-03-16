using System;

namespace SeeSharpersCinema.Infrastructure
{
    public static class DateHelper
    {
        public static string GetDay()
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;
            return today.ToString();
        }

        /// <summary>
        /// Gets the amount of days untill it is Thursday,  and adds this to the current date.
        /// </summary>
        /// <returns>The date of the first upcomming Thursday</returns>
        public static DateTime GetNextThursday()
        {
            DateTime today = DateTime.Now.Date;
            int daysUntilThursday = ((int)DayOfWeek.Thursday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextThursday = today.AddDays(daysUntilThursday);
            return nextThursday;
        }

        /// <summary>
        /// Converts an userinput string to DateTime
        /// </summary>
        /// <param name="uiDate">string</param>
        /// <returns>A date string converted to DateTime</returns>
        public static DateTime StringToDateTime(string uiDate)
        {
            string[] parts = uiDate.Split('-');
            int year = Int32.Parse(parts[0]);
            int month = Int32.Parse(parts[1]);
            int day = Int32.Parse(parts[2]);

            return new DateTime(year, month, day, 00, 00, 00);
        }
    }
}
