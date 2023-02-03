using Infrastructure.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _context;

        protected DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {

            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id) => await dbSet.FindAsync(id);

        public async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var exist = await dbSet.Where(item => item.Id == id).FirstOrDefaultAsync();

            if (exist != null)
            {
                dbSet.Remove(exist);
                return true;
            }

            return false;
        }

        public async Task<bool> Update(T entity)
        {
            _context.Entry(await dbSet.FirstOrDefaultAsync(item => item.Id == entity.Id)).CurrentValues.SetValues(entity);
            return true;
        }
    }
}
