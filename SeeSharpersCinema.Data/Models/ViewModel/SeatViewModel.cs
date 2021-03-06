using SeeSharpersCinema.Data.Models.Theater;
using SeeSharpersCinema.Models;
using SeeSharpersCinema.Models.Film;
using System.Collections.Generic;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    /// <summary>
    /// SeatViewModel used by the Seat View.
    /// </summary>
    public class SeatViewModel
    {
        public TimeSlot TimeSlot { get; set; }
        public Movie Movie { get; set; }
        public string SeatingArrangement { get; set; }
        public long PlayListId { get; set; }
        public long TimeSlotId { get; set; }
    }
}
