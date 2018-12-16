using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface IProvinceRepository : IReadWriteRepository<Province>
    {
        Task<IEnumerable<Province>> GetProvincesAsync();
        Task<IDictionary<int, Province>> GetProvincesAsync(IEnumerable<int> provinceIds, CancellationToken token);
        Task<IEnumerable<Province>> GetProvincesByStateIdAsync(int stateId);
        Task<ILookup<int, Province>> GetProvincesByStateIdsAsync(IEnumerable<int> stateIds);
        Task<Province> GetProvinceByIdAsync(int id);
        Task<Province> GetProvinceByCodeAsync(string code);
    }
}
