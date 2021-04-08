using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Models.Database;
using SeeSharpersCinema.Models.Film;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Models.Repository
{
    public class EFMovieRepository : IMovieRepository
    {
        private CinemaDbContext context;
        public IQueryable<Movie> Movies => context.Movies;

        /// <summary>
        /// EFMovieRepository constructor
        /// </summary>
        /// <param name="ctx">Constructor needs a CinemaDbContext object</param>
        public EFMovieRepository(CinemaDbContext ctx)
        {
            context = ctx;
        }

        /// <summary>
        /// Gets a collection of type Movie from the database.
        /// </summary>
        public async Task<IEnumerable<Movie>> FindAllAsync()
            => await context.Movies
            .OrderBy(m => m.Title)
            .ToListAsync();

        /// <summary>
        /// Gets an object of type Movie from the database.
        /// </summary>
        /// <param name="MovieId">The movieId on which to search. This is defined by the method in SeatController.</param>
        public async Task<Movie> FindByIdAsync(long MovieId)
            => await context.Movies
            .Where(t => t.Id == MovieId)
            .FirstOrDefaultAsync();

        /// <summary>
        /// Updates an object of type Movie in the the database.
        /// </summary>
        /// <param name="MovieId">The movieId on which to search. This is defined by the method in SeatController.</param>
        public async Task UpdateMovieDetailsAsync(Movie movie) {
            context.Update(movie);
            await context.SaveChangesAsync();

        }

        /// <summary>
        /// Add an object of type Movie in the the database.
        /// </summary>
        /// <param name="Movie">The object of type Movie to add. This is defined by the method in SeatController.</param>
        public async Task AddMovieAsync(Movie movie)
        {
            await context.AddAsync(movie);
            await context.SaveChangesAsync();
        }

    }
}
