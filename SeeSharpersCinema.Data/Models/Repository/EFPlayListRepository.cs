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
    /// <summary>
    /// EFPlayListRepository queries and stores database data
    /// </summary>
    public class EFPlayListRepository : IPlayListRepository
    {
        private CinemaDbContext context;

        /// <summary>
        /// Constructor EFPlayListRepository
        /// </summary>
        /// <param name="ctx">EFPlayListRepository needs a CinemaDbContext object</param>
        public EFPlayListRepository(CinemaDbContext ctx)
        {
            context = ctx;
        }

        //Add Movies to read specific movie in details view
        public IQueryable<Movie> Movies => context.Movies;

        /// <summary>
        /// Queries the database to find all movies in a task for correct threading
        /// </summary>
        /// <returns>IEnumerable list of PlayList objects</returns>
        public async Task<IEnumerable<PlayList>> FindAllAsync()
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .Include(r => r.TimeSlot.Room)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .ToListAsync();

        /// <summary>
        /// Queries the database to return movies between specific dates.
        /// </summary>
        /// <param name="startDate">From when it should add movies to the list. This is defined by the method in HomeController.</param>
        /// <param name="endDate">Untill what date it should add movies to the list. This is defined by the method in HomeController.</param>
        /// <returns>Movies between startDate and endDate</returns>
        public async Task<IEnumerable<PlayList>> FindBetweenDatesAsync(DateTime startDate, DateTime endDate)
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .Where(z => z.TimeSlot.SlotStart.Date >= startDate && z.TimeSlot.SlotStart.Date <= endDate)
            .ToListAsync();

        /// <summary>
        /// Queries the database to find a movie by title in a task for correct threading
        /// </summary>
        /// <param name="startDate">From when it should add movies to the list. This is defined by the method in HomeController.</param>
        /// <param name="endDate">Untill what date it should add movies to the list. This is defined by the method in HomeController.</param>
        /// <param name="uiTitle">Selection string: user input title from HomeController</param>
        /// <returns>Movie with this title</returns>
        public async Task<IEnumerable<PlayList>> FindByTitle(DateTime startDate, DateTime endDate, string uiTitle)
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .Where(z => z.TimeSlot.SlotStart.Date >= startDate && z.TimeSlot.SlotStart.Date <= endDate && z.Movie.Title.Contains(uiTitle))
            .ToListAsync();

        /// <summary>
        /// Queries the database to find movies by date in a task for correct threading
        /// </summary>
        /// <param name="uiDate">Selection string: user input DateTime date from HomeController</param>
        /// <returns>Movies shown at this date</returns>
        public async Task<IEnumerable<PlayList>> FindByDate(DateTime uiDate)
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .Where(z => z.TimeSlot.SlotStart.Date == uiDate)
            .ToListAsync();

        /// <summary>
        /// Queries the database to find movies by genre in a task for correct threading
        /// </summary>
        /// <param name="startDate">From when it should add movies to the list. This is defined by the method in HomeController.</param>
        /// <param name="endDate">Untill what date it should add movies to the list. This is defined by the method in HomeController.</param>
        /// <param name="uiGenre">Selection string: user input genre from HomeController</param>
        /// <returns>Movies with this genre</returns>
        public async Task<IEnumerable<PlayList>> FindByGenre(DateTime startDate, DateTime endDate, string uiGenre)
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .Where(z => z.TimeSlot.SlotStart.Date >= startDate && z.TimeSlot.SlotStart.Date <= endDate &&
                    z.Movie.Genre.Equals(Enum.Parse(typeof(Genre), uiGenre)))
            .ToListAsync();

        /// <summary>
        /// Queries the database to find movies by title and date in a task for correct threading
        /// </summary>
        /// <param name="uiTitle">Selection string: user input title from HomeController</param>
        /// <param name="uiDate">Selection string: user input DateTime date from HomeController</param>
        /// <returns>Movies with this title shown at this date</returns>
        public async Task<IEnumerable<PlayList>> FindByTitleAndDate(string uiTitle, DateTime uiDate)
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .Where(z => z.Movie.Title.Contains(uiTitle) && z.TimeSlot.SlotStart.Date == uiDate)
            .ToListAsync();

        /// <summary>
        /// Queries the database to find movies by date and genre in a task for correct threading
        /// </summary>
        /// <param name="uiDate">Selection string: user input DateTime date from HomeController</param>
        /// <param name="uiGenre">Selection string: user input DateTime date from HomeController</param>
        /// <returns>Movies shown at this date with this genre</returns>
        public async Task<IEnumerable<PlayList>> FindByDateAndGenre(DateTime uiDate, string uiGenre)
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .Where(z => z.TimeSlot.SlotStart.Date == uiDate && z.Movie.Genre.Equals(Enum.Parse(typeof(Genre), uiGenre)))
            .ToListAsync();

        /// <summary>
        /// Queries the database to find movies by view indication in a task for correct threading
        /// </summary>
        /// <param name="startDate">From when it should add movies to the list. This is defined by the method in HomeController.</param>
        /// <param name="endDate">Untill what date it should add movies to the list. This is defined by the method in HomeController.</param>
        /// <param name="uiViewIndication">Selection string: user input view indication from HomeController</param>
        /// <returns></returns>
        public async Task<IEnumerable<PlayList>> FindByViewIndication(DateTime startDate, DateTime endDate, string uiViewIndication)
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .Where(z => z.TimeSlot.SlotStart.Date >= startDate && z.TimeSlot.SlotStart.Date <= endDate &&
                    z.Movie.ViewIndication.Equals(Enum.Parse(typeof(ViewIndication), uiViewIndication)))
            .ToListAsync();

        /// <summary>
        /// Queries the database to find movies shown at this date with this view indication in a task for correct threading
        /// </summary>
        /// <param name="uiDate">Selection string: user input DateTime date from HomeController</param>
        /// <param name="uiViewIndication">Selection string: user input view indication from HomeController</param>
        /// <returns>Movies shown at this date with this view indication</returns>
        public async Task<IEnumerable<PlayList>> FindByDateAndViewIndication(DateTime uiDate, string uiViewIndication)
            => await context.PlayLists
            .Include(b => b.Movie)
            .Include(c => c.TimeSlot)
            .OrderBy(p => p.TimeSlot.SlotStart)
            .ThenBy(q => q.TimeSlot.RoomId)
            .Where(z => z.TimeSlot.SlotStart.Date == uiDate && z.Movie.ViewIndication.Equals(Enum.Parse(typeof(ViewIndication), uiViewIndication)))
            .ToListAsync();

        /// <summary>
        /// Queries the database to find movies with this view indication and genre in a task for correct threading
        /// </summary>
        /// <param name="startDate">From when it should add movies to the list. This is defined by the method in HomeController.</param>
        /// <param name="endDate">Untill what date it should add movies to the list. This is defined by the method in HomeController.</param>
        /// <param name="uiViewIndication">Selection string: user input view indication from HomeController</param>
        /// <param name="uiGenre">Selection string: user input DateTime date from HomeController</param>
        /// <returns></returns>
        public async Task<IEnumerable<PlayList>> FindByViewIndicationAndGenre(DateTime startDate, DateTime endDate, string uiViewIndication, string uiGenre)
           => await context.PlayLists
           .Include(b => b.Movie)
           .Include(c => c.TimeSlot)
           .OrderBy(p => p.TimeSlot.SlotStart)
           .ThenBy(q => q.TimeSlot.RoomId)
           .Where(z => z.TimeSlot.SlotStart.Date >= startDate && z.TimeSlot.SlotStart.Date <= endDate &&
                   z.Movie.ViewIndication.Equals(Enum.Parse(typeof(ViewIndication), uiViewIndication)) &&
                   z.Movie.Genre.Equals(Enum.Parse(typeof(Genre), uiGenre)))
           .ToListAsync();
    }
}
