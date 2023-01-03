using Infrastructure.Data;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class BoardRepository : GenericRepository<BoardEntity>, IBoardRepository
    {
        public BoardRepository(ApplicationDbContext context ) : base(context)
        {
        }

    }
}
