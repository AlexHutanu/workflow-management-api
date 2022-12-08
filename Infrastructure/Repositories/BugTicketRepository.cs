using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.IRepositories;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BugTicketRepository : GenericRepository<BugTicket>, IBugTicketRepository
    {
        public BugTicketRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }


        public override async Task<IEnumerable<BugTicket>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(BugTicketRepository));
                return new List<BugTicket>();
            }
        }
        public override async Task<bool> Update(BugTicket entity)
        {

            try
            {
                var existingBugTicket = await dbSet.Where(bugTicket =>  bugTicket.Id == entity.Id).FirstOrDefaultAsync();

                if (existingBugTicket == null)
                    return await Add(entity);

                existingBugTicket.Name = entity.Name;
                existingBugTicket.Description = existingBugTicket.Description;
                existingBugTicket.Status = existingBugTicket.Status;
                existingBugTicket.Deadline = existingBugTicket.Deadline;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(BugTicketRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(bugTicket => bugTicket.Id == id).FirstOrDefaultAsync();

                if (exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(BugTicketRepository));
                return false;
            }
        }
    }
}
