
using SeeSharpersCinema.Data.Program;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeeSharpersCinema.Models.Program
{
    public class ReservedSeat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TimeSlotId { get; set; }
        public int SeatId { get; set; }
        public int RowId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public SeatState SeatState { get; set; }

    }
}
