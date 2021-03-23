using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Models.Database;
using SeeSharpersCinema.Models.Website;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Models.Repository
{
    public class EFNoticeRepository : INoticeRepository
    {
        private CinemaDbContext context;

        public EFNoticeRepository(CinemaDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Notice> Notices => context.Notices;
        public async Task<IEnumerable<Notice>> FindFirstNotice() => await context.Notices.ToListAsync();
    }
}
