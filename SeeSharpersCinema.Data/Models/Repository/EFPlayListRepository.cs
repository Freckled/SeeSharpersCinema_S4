using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Models.Database;
using SeeSharpersCinema.Models.Film;
using SeeSharpersCinema.Models.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Models.Repository
{
    public class EFPlayListRepository : IPlayListRepository
    {
        private CinemaDbContext context;

        public EFPlayListRepository(CinemaDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Movie> Movies => context.Movies;

        //public IQueryable<PlayList> PlayLists => context.PlayLists;

        public async Task<IEnumerable<PlayList>> FindAllAsync()
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .ToListAsync();

        public async Task<IEnumerable<PlayList>> FindBetweenDatesAsync(DateTime startDate, DateTime endDate)
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .Where(z => z.TimeSlot.SlotStart.Date >= startDate && z.TimeSlot.SlotStart.Date <= endDate)
            .ToListAsync();
    }
}
