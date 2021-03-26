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
        /// <summary>
        /// IPlayListRepository interface makes sure these methods are implemented
        /// in a taks for correct threading
        /// </summary>
        /// <returns>IEnumerable<PlayList> objects</returns>
        public Task<IEnumerable<PlayList>> FindBetweenDatesAsync(DateTime startDate, DateTime endDate);
        public Task<IEnumerable<PlayList>> FindByTitle(DateTime startDate, DateTime endDate, string uiTitle);
        public Task<IEnumerable<PlayList>> FindByDate(DateTime uiDate);
        public Task<IEnumerable<PlayList>> FindByGenre(DateTime startDate, DateTime endDate, string uiGenre);
        public Task<IEnumerable<PlayList>> FindByTitleAndDate(string uiTitle, DateTime uiDate);
        public Task<IEnumerable<PlayList>> FindByDateAndGenre(DateTime uiDate, string uiGenre);
        public Task<IEnumerable<PlayList>> FindByViewIndication(DateTime startDate, DateTime endDate, string uiViewIndication);
        public Task<IEnumerable<PlayList>> FindByDateAndViewIndication(DateTime uiDate, string uiViewIndication);
        public Task<IEnumerable<PlayList>> FindByViewIndicationAndGenre(DateTime startDate, DateTime endDate, string uiViewIndication, string uiGenre);
    }
}
