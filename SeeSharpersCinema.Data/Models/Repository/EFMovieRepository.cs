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

        public async Task<IEnumerable<Movie>> FindAllAsync()
            => await context.Movies
            .OrderBy(m => m.Title)
            .ToListAsync();

        public async Task<Movie> FindByIdAsync(long MovieId)
            => await context.Movies
            .Where(t => t.Id == MovieId)
            .FirstOrDefaultAsync();


        public async Task UpdateMovieDetailsAsync(Movie movie) {
            context.Update(movie);
            await context.SaveChangesAsync();

        }


        public async Task AddMovieAsync(Movie movie)
        {
            await context.AddAsync(movie);
            await context.SaveChangesAsync();
        }

    }
}
