using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _context;

        protected DbSet<T> dbSet;

        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            this.dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id) => await dbSet.FindAsync(id);

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var exist = await dbSet.Where(item => item.Id == id).FirstOrDefaultAsync();

            if (exist != null)
            {
                dbSet.Remove(exist);
                return true;
            }

            return false;
        }

        public virtual async Task<bool> Update(T entity)
        {
            _context.Entry(await dbSet.FirstOrDefaultAsync(item => item.Id == entity.Id)).CurrentValues.SetValues(entity);
            return true;
        }
    }
}
