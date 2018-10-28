using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.Infrastructure.Repository
{
    public abstract class ReadOnlyRepository<TEntity>
        where TEntity: class
    {
        private readonly DbContext _dbContext;

        protected ReadOnlyRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; }

        protected async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        protected async Task<IEnumerable<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbContext.Set<TEntity>().Where(filter).ToListAsync();
        }

        protected Task<TEntity> FindAsync(params object[] keyValues)
        {
            return _dbContext.Set<TEntity>().FindAsync(keyValues);
        }

        protected Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().FirstOrDefaultAsync(filter);
        }
    }
}
