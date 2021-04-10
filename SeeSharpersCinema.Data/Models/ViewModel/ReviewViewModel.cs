using SeeSharpersCinema.Models.Film;
using System;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    /// <summary>
    /// ReviewViewModel used by the Post view
    /// this combines the Movies and required information for reviews
    /// </summary>
    public class ReviewViewModel
    {
        public Movie Movie { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public long MovieId { get; set; }
        public DateTime Date { get; set; }
    }
}
