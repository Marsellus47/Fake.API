using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class CommunityRepository : ICommunityRepository
    {
        private readonly CountryDataContext _countryDataContext;

        public CommunityRepository(CountryDataContext countryDataContext)
        {
            _countryDataContext = countryDataContext;
        }
        public async Task<IEnumerable<Community>> GetCommunitiesAsync()
        {
            return await _countryDataContext.Community.ToListAsync();
        }

        public async Task<IEnumerable<Community>> GetCommunitiesByProvinceIdAsync(int provinceId)
        {
            return await _countryDataContext.Community.Where(community => community.ProvinceId == provinceId).ToListAsync();
        }

        public Task<Community> GetCommunityByIdAsync(int id)
        {
            return _countryDataContext.Community.FindAsync(id);
        }

        public Task<Community> GetCommunityByCodeAsync(string code)
        {
            return _countryDataContext.Community.FirstOrDefaultAsync(community => community.Code == code);
        }
    }
}
