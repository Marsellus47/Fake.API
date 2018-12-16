using Fake.DataAccess.Database.Infrastructure.Model;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Fake.DataAccess.Database.Infrastructure.Repository
{
    public abstract class ReadWriteRepository<TEntity> : ReadOnlyRepository<TEntity>, IReadWriteRepository<TEntity>
        where TEntity: Entity
    {
        private const string idColumnName = nameof(Entity.Id);

        protected ReadWriteRepository(DbContext dbContext)
            : base(dbContext) { }

        public async Task InsertAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (!DbSet.Any(x => x.Id == entity.Id))
                return;

            DbSet.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<TEntity> PartiallyUpdateAsync(IDictionary<string, object> values)
        {
            var idValue = values[idColumnName.Camelize()];
            int id = idValue is int ? (int)idValue : int.Parse(idValue as string);
            TEntity entity = await FindAsync(id);

            if (entity == null)
                return null;

            if(values.Any(NonIdColumnCondition))
            {
                foreach (var value in values.Where(NonIdColumnCondition))
                {
                    var property = typeof(TEntity).GetProperty(value.Key.Pascalize());
                    var propertyValue = Convert.ChangeType(value.Value, property.PropertyType);
                    property.SetValue(entity, propertyValue);
                }

                DbSet.Update(entity);
                await DbContext.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            TEntity entity = await DbSet.SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            DbContext.Remove(entity);
            await DbContext.SaveChangesAsync();
            return true;
        }

        private readonly Func<KeyValuePair<string, object>, bool> NonIdColumnCondition
            = pair => pair.Key != idColumnName.Camelize();
    }
}
