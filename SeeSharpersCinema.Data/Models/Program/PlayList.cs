using SeeSharpersCinema.Models.Film;
using SeeSharpersCinema.Models.Theater;
using System;
using System.Collections.Generic;

namespace SeeSharpersCinema.Models.Program
{
    public class PlayList
    {
        public long Id { get; set; }
        public long TimeSlotId { get; set; }
        public long MovieId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public Movie Movie { get; set; }
    }
}
