using Infrastructure.Data;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class BugTicketRepository : GenericRepository<BugTicket>, IBugTicketRepository
    {
        public BugTicketRepository(ApplicationDbContext context ) : base(context)
        {
        }
    }
}
