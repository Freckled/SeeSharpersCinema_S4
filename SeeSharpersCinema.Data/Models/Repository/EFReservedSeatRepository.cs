using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Data.Models.Program;
using SeeSharpersCinema.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.Repository
{
    public class EFReservedSeatRepository: IReservedSeatRepository
    {
        private CinemaDbContext context;

        public EFReservedSeatRepository(CinemaDbContext ctx)
        {
            context = ctx;
        }

        //public IQueryable<ReservedSeat> ReservedSeat => context.ReservedSeats;

        public async Task<IEnumerable<ReservedSeat>> FindAllAsync()
            => await context.ReservedSeats
            //.Include(s => s.SeatId)
            .Include(c => c.TimeSlot)
            .OrderBy(q => q.TimeSlotId)
            .ToListAsync();

        public async Task<IEnumerable<ReservedSeat>> FindAllByTimeSlotIdAsync(long TimeSlotId)
            => await context.ReservedSeats
            //.Include(s => s.SeatId)
            .Include(c => c.TimeSlot)
            .Include(r => r.TimeSlot.Room)
            .Where(t => t.TimeSlotId == TimeSlotId)
            .ToListAsync();
    }
}
