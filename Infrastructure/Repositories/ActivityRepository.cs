using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class ActivityRepository : GenericRepository<ActivityEntity>, IActivityRepository
    {
            public ActivityRepository(ApplicationDbContext context) : base(context)
            {
            }

        }
    }


