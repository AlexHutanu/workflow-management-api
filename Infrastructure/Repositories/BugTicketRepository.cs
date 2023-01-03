using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Infrastructure.Repositories
{
    public class BugTicketRepository : GenericRepository<Infrastructure.Entities.BugTicketEntity>, IBugTicketRepository
    {

        protected ApplicationDbContext _context;
        protected DbSet<Infrastructure.Entities.BugTicketEntity> _dbSet;


        public BugTicketRepository(ApplicationDbContext context ) : base(context)
        {
            _context = context;
            this.dbSet= context.Set<BugTicketEntity>();
        }

        public async Task<IEnumerable<Infrastructure.Entities.BugTicketEntity>> GetByBoardId(Guid boardId)
        {
            return await dbSet.Where(bugTicket => bugTicket.Id == boardId).ToListAsync();
            
        }
    }
}
