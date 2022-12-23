using Infrastructure.Data;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class BoardRepository : GenericRepository<Board>, IBoardRepository
    {
        public BoardRepository(ApplicationDbContext context ) : base(context)
        {
        }

    }
}
