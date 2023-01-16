using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Infrastructure.Repositories
{
    public class TicketRepository : GenericRepository<Infrastructure.Entities.TicketEntity>, ITicketRepository
    {

        protected DbSet<Infrastructure.Entities.TicketEntity> _dbSet;


        public TicketRepository(ApplicationDbContext context ) : base(context)
        {
            this.dbSet= context.Set<TicketEntity>();
        }

        public async Task<IEnumerable<Infrastructure.Entities.TicketEntity>> GetByBoardId(Guid boardId)
        {
            return await dbSet.Where(ticket => ticket.BoardId == boardId).ToListAsync();
        }

        public async Task<IEnumerable<TicketEntity>> GetByName(string name)
        {
            return await dbSet.Where(ticket => ticket.Name.Contains(name)).ToListAsync();
        }
    }
}
