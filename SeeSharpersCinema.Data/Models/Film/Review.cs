using SeeSharpersCinema.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.Film
{
    public class Review
    {
        public long Id { get; set; }
        public int score { get; set; }
        public Movie Movie { get; set; }
        public string Text { get; set; }
    }
}
