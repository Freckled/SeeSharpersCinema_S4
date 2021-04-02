﻿using SeeSharpersCinema.Data.Models.Film;
using SeeSharpersCinema.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    public class DetailsViewModel
    {
        public Movie Movie { get; set; }
        public long PlayListId { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
