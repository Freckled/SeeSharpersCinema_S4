using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Models.Database;
using SeeSharpersCinema.Models.Order;
using SeeSharpersCinema.Models.Theater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Models.Repository
{
    public class EFTicketRepository : ITicketRepository
    {
        private CinemaDbContext context;
        public IQueryable<Ticket> Tickets => context.Tickets
            .Include(m => m.Movie)
            .Include(r => r.Room)
            .Include(ts => ts.TimeSlot);
    }
}
