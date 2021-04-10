using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Models.Database;
using SeeSharpersCinema.Models.Website;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Models.Repository
{
    public class EFNoticeRepository : INoticeRepository
    {
        private CinemaDbContext context;

        /// <summary>
        /// EFNoticeRepository constructor
        /// </summary>
        /// <param name="ctx">Constructor needs a CinemaDbContext object</param>
        public EFNoticeRepository(CinemaDbContext ctx)
        {
            context = ctx;
        }

        /// <summary>
        /// 
        /// </summary>
        public IQueryable<Notice> Notices => context.Notices;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Notice>> FindFirstNotice() => await context.Notices.ToListAsync();
    }
}
/// <summary>
/// Queries the database to return all Reserved Seats between specific dates.
/// </summary>
/// <param name="TimeSlotId">The TimeSlotId the reserved seats should match. This is defined by the method in SeatController.</param>
/// <returns>ReservedSeats that match the TimeSlotId</returns>