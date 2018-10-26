using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly CountryDataContext _countryDataContext;

        public ProvinceRepository(CountryDataContext countryDataContext)
        {
            _countryDataContext = countryDataContext;
        }
        public async Task<IEnumerable<Province>> GetProvincesAsync()
        {
            return await _countryDataContext.Province.ToListAsync();
        }

        public async Task<IEnumerable<Province>> GetProvincesByStateIdAsync(int stateId)
        {
            return await _countryDataContext.Province.Where(province => province.StateId == stateId).ToListAsync();
        }

        public Task<Province> GetProvinceByIdAsync(int id)
        {
            return _countryDataContext.Province.FindAsync(id);
        }

        public Task<Province> GetProvinceByCodeAsync(string code)
        {
            return _countryDataContext.Province.FirstOrDefaultAsync(province => province.Code == code);
        }
    }
}
