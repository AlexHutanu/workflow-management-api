using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
            public ActivityRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
            {
            }


            public override async Task<IEnumerable<Activity>> GetAll()
            {
                try
                {
                    return await dbSet.ToListAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "{Repo} All method error", typeof(IActivityRepository));
                    return new List<Activity>();
                }
            }

            public override async Task<bool> Update(Activity entity)
            {

                try
                {
                    var existingActivity= await dbSet.Where(activity => activity.Id == entity.Id).FirstOrDefaultAsync();

                    if (existingActivity == null)
                        return await Add(entity);

                    existingActivity.Name = entity.Name;
                    existingActivity.Description = entity.Description;

                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "{Repo} All method error", typeof(IActivityRepository));
                    return false;
                }
            }

            public override async Task<bool> Delete(Guid id)
            {
                try
                {
                    var exist = await dbSet.Where(activity => activity.Id == id).FirstOrDefaultAsync();

                    if (exist != null)
                    {
                        dbSet.Remove(exist);
                        return true;
                    }

                    return false;

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "{Repo} All method error", typeof(ActivityRepository));
                    return false;
                }
            }
        }
    }


