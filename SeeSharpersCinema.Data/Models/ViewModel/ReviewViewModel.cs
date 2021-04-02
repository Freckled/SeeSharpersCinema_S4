using SeeSharpersCinema.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    public class ReviewViewModel
    {
        public Movie Movie { get; set; }
        public int Rating { get; set; }
        public string Message { get; set; }
        public long MovieId { get; set; }
        
    }
}
