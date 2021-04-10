using SeeSharpersCinema.Data.Models.Film;
using SeeSharpersCinema.Models.Film;
using System.Collections.Generic;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    /// <summary>
    /// DetailsViewModel used by the Detail view (index)
    /// this combines the Movies and Reviews
    /// </summary>
    public class DetailsViewModel
    {
        public Movie Movie { get; set; }
        public long PlayListId { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
