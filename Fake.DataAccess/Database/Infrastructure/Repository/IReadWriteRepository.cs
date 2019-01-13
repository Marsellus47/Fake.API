using Fake.DataAccess.Database.Infrastructure.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.Infrastructure.Repository
{
    public interface IReadWriteRepository<TEntity>
        where TEntity : Entity
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> PartiallyUpdateAsync(IDictionary<string, object> values);
        Task<bool> DeleteAsync(int id);
    }
}
