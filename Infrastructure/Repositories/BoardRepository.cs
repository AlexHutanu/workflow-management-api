using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BoardRepository : GenericRepository<Board>, IBoardRepository
    {
        public BoardRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }


        public override async Task<IEnumerable<Board>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(BoardRepository));
                return new List<Board>();
            }
        }
        public override async Task<bool> Update(Board entity)
        {

            try
            {
                var existingBoard = await dbSet.Where(board => board.Id == entity.Id).FirstOrDefaultAsync();

                if (existingBoard == null)
                    return await Add(entity);

                existingBoard.Name = entity.Name;
                existingBoard.Description = entity.Description;
                existingBoard.NoOfTickets = entity.NoOfTickets;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(BoardRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(board => board.Id == id).FirstOrDefaultAsync();

                if (exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(BoardRepository));
                return false;
            }
        }
    }
}
