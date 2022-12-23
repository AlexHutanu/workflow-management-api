using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
            public ActivityRepository(ApplicationDbContext context) : base(context)
            {
            }

        }
    }


