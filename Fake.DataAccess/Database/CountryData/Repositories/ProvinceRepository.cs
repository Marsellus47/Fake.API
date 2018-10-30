using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class ProvinceRepository : ReadOnlyRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public Task<IEnumerable<Province>> GetProvincesAsync()
        {
            return GetAllAsync();
        }

        public async Task<IDictionary<int, Province>> GetProvincesAsync(IEnumerable<int> provinceIds, CancellationToken token)
        {
            return await DbSet.Where(province => provinceIds.Contains(province.Id))
                .ToDictionaryAsync(province => province.Id, token);
        }

        public Task<IEnumerable<Province>> GetProvincesByStateIdAsync(int stateId)
        {
            return GetFilteredAsync(province => province.StateId == stateId);
        }

        public async Task<ILookup<int, Province>> GetProvincesByStateIdsAsync(IEnumerable<int> stateIds)
        {
            var provinces = await GetFilteredAsync(province => stateIds.Contains(province.StateId));
            return provinces.ToLookup(province => province.StateId);
        }

        public Task<Province> GetProvinceByIdAsync(int id)
        {
            return FindAsync(id);
        }

        public Task<Province> GetProvinceByCodeAsync(string code)
        {
            return GetFirstAsync(province => province.Code == code);
        }
    }
}
