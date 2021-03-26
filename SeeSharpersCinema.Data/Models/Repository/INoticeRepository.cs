using SeeSharpersCinema.Models.Website;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Models.Repository
{
    public interface INoticeRepository
    {
        /// <summary>
        /// INoticeRepository interface makes sure classes implement 
        /// a property of type IQueryable<Notice>
        /// </summary>
        IQueryable<Notice> Notices { get; }

        public Task<IEnumerable<Notice>> FindFirstNotice();
    }
}
