using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {

         protected DbSet<UserEntity> _dbSet;
        

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            this.dbSet = context.Set<UserEntity>();
        }

        public  UserEntity GetByEmail(string email)
        {
            return  dbSet.FirstOrDefault(user => user.Email == email);
        }
    }
}
