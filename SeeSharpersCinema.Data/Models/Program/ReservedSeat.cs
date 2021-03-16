using SeeSharpersCinema.Models;
using SeeSharpersCinema.Models.Theater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.Program
{
    public class ReservedSeat
    {
        public long Id { get; set; }
        public long TimeSlotId { get; set; }
        public int SeatId {get; set;}
        public TimeSlot TimeSlot { get; set; }

    }
}
