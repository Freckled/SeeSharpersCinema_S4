using SeeSharpersCinema.Models.Film;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Models.Repository
{
    public interface IMovieRepository
    {
        /// <summary>
        /// IMovieRepository interface makes sure classes implement 
        /// a property of type IQueryable<Movie>
        /// </summary>
        IQueryable<Movie> Movies { get; }
        Task AddMovieAsync(Movie movie);
        Task<Movie> FindByIdAsync(long Id);
        Task UpdateMovieDetailsAsync(Movie movie);
        Task<IEnumerable<Movie>> FindAllAsync();
    }
}
