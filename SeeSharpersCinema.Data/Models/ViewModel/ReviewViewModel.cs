using SeeSharpersCinema.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    class ReviewViewModel
    {
        Movie Movie { get; set; }
        int Score { get; set; }
        string Text { get; set; }

    }
}
