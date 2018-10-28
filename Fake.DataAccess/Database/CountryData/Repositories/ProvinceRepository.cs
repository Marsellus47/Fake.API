using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<IEnumerable<Province>> GetProvincesByStateIdAsync(int stateId)
        {
            return GetFilteredAsync(province => province.StateId == stateId);
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
