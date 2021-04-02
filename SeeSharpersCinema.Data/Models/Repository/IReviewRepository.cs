using SeeSharpersCinema.Data.Models.Film;
using SeeSharpersCinema.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.Repository
{
    /// <summary>
    /// IReservedSeatRepository interface makes sure these methods are implemented
    /// in a tasks for correct threading
    /// </summary>
    /// <returns>IEnumerable<ReservedSeat> objects or ICollection<ReservedSeat> object</returns>
    public interface IReviewRepository : IRepository<Review>
    {
        public Task<IEnumerable<Review>> FindAllByMovieIdAsync(long MovieId);
        public Task PostReview(Review review);

    }
}
