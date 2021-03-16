using SeeSharpersCinema.Models.Order;
using System.Linq;

namespace SeeSharpersCinema.Models.Repository
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> Tickets { get; }
    }
}
