using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Data.Models.Film;
using SeeSharpersCinema.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.Repository
{
    public class EFReviewRepository : IReviewRepository
    {
        private CinemaDbContext context;

        public EFReviewRepository(CinemaDbContext ctx)
        {
            context = ctx;
        }

        /// <summary>
        /// Queries the database to return all Reviews.
        /// </summary>
        /// <returns>IEnumerable<Review></returns>
        public async Task<IEnumerable<Review>> FindAllAsync()
            => await context.Reviews
            .Include(c => c.Movie)
            .OrderBy(q => q.score)
            .ToListAsync();

        /// <summary>
        /// Queries the database to return all reviews by MovieId.
        /// </summary>
        /// <param name="MovieId">The MovieId the reviews should match. This is defined by the method in ReviewController.</param>
        /// <returns>IEnumerable<Review> that match the MovieId</returns>
        public async Task<IEnumerable<Review>> FindAllByMovieIdAsync(long MovieId)
            => await context.Reviews
            .Where(t => t.Movie.Id == MovieId)
            .ToListAsync();


        /// <summary>
        /// Adds a movie Review to the database.
        /// </summary>
        /// <param name="review">A movie review. This is defined by the method in ReviewController.</param>
        public async Task PostReview(Review review)
        {
            try
            {
                await context.AddRangeAsync(review);
                var saveResult = await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

    }
}
