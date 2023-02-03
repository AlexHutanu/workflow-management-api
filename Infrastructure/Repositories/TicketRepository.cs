using Infrastructure.Data;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Infrastructure.Repositories
{
    public class TicketRepository : GenericRepository<TicketEntity>, ITicketRepository
    {

        protected DbSet<TicketEntity> _dbSet;


        public TicketRepository(ApplicationDbContext context ) : base(context)
        {
            this.dbSet= context.Set<TicketEntity>();
        }

        public async Task<IEnumerable<TicketEntity>> GetByBoardId(Guid boardId)
        {
            return await dbSet.Where(ticket => ticket.BoardId == boardId).ToListAsync();
        }

        public async Task<IEnumerable<TicketEntity>> GetByName(string name)
        {
            return await dbSet.Where(ticket => ticket.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<TicketEntity>> GetByUserId(Guid userId)
        {
            return await dbSet.Where(ticket => ticket.Assignee == userId).ToListAsync();
        }
    }
}
