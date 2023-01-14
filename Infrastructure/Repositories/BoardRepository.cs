using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BoardRepository : GenericRepository<BoardEntity>, IBoardRepository
    {

        protected DbSet<BoardEntity> _dbSet;

        public BoardRepository(ApplicationDbContext context ) : base(context)
        {
            this.dbSet = context.Set<BoardEntity>();
        }

        public async Task<IEnumerable<BoardEntity>> GetByName(string name)
        {
            return await dbSet.Where(board => board.Name.Contains(name)).ToListAsync();
        }

    }
}
