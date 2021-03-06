﻿using Fake.DataAccess.Database.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Fake.DataAccess.Database.Infrastructure.Repository
{
    public abstract class ReadOnlyRepository<TEntity>
        where TEntity: Entity
    {
        protected ReadOnlyRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        protected DbContext DbContext { get; }

        protected DbSet<TEntity> DbSet { get; }

        protected DbSet<T> GetDbSet<T>()
            where T : class
        {
            return DbContext.Set<T>();
        }

        protected async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        protected async Task<IEnumerable<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await DbSet.Where(filter).ToListAsync();
        }

        protected Task<TEntity> FindAsync(params object[] keyValues)
        {
            return DbSet.FindAsync(keyValues);
        }

        protected Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.FirstOrDefaultAsync(filter);
        }
    }
}
