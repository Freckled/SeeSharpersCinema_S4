using SeeSharpersCinema.Models.Film;
using SeeSharpersCinema.Models.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Models.Repository
{
    public interface IPlayListRepository : IRepository<PlayList>
    {
        //IQueryable<PlayList> PlayLists { get; }
        public Task<IEnumerable<PlayList>> FindBetweenDatesAsync(DateTime startDate, DateTime endDate);
        IQueryable<Movie> Movies { get; }
    }
}
