using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Models.Database;
using SeeSharpersCinema.Models.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.Repository
{
    public class EFReservedSeatRepository : IReservedSeatRepository
    {
        private CinemaDbContext context;

        public EFReservedSeatRepository(CinemaDbContext ctx)
        {
            context = ctx;
        }

        /// <summary>
        /// Queries the database to return all Reserved Seats between specific dates.
        /// </summary>
        /// <returns>ReservedSeats</returns>
        public async Task<IEnumerable<ReservedSeat>> FindAllAsync()
            => await context.ReservedSeats
            .Include(c => c.TimeSlot)
            .OrderBy(q => q.TimeSlotId)
            .ToListAsync();

        /// <summary>
        /// Queries the database to return all Reserved Seats between specific dates.
        /// </summary>
        /// <param name="TimeSlotId">The TimeSlotId the reserved seats should match. This is defined by the method in SeatController.</param>
        /// <returns>ReservedSeats that match the TimeSlotId</returns>
        public async Task<IEnumerable<ReservedSeat>> FindAllByTimeSlotIdAsync(long TimeSlotId)
            => await context.ReservedSeats
            .Include(c => c.TimeSlot)
            .Include(r => r.TimeSlot.Room)
            .Where(t => t.TimeSlotId == TimeSlotId)
            .ToListAsync();


        /// <summary>
        /// Adds a collection of type ReservedSeat to the database.
        /// </summary>
        /// <param name="reservedSeat">A collection of Type Reserved Seat. This is defined by the method in SeatController.</param>
        public async Task ReserveSeats(ICollection<ReservedSeat> reservedSeat)
        {
            try
            {
                await context.AddRangeAsync(reservedSeat);
                var saveResult = await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

    }
}
