using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class CommunityRepository : ReadOnlyRepository<Community>, ICommunityRepository
    {
        public CommunityRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public Task<IEnumerable<Community>> GetCommunitiesAsync()
        {
            return GetAllAsync();
        }

        public Task<IEnumerable<Community>> GetCommunitiesByProvinceIdAsync(int provinceId)
        {
            return GetFilteredAsync(community => community.ProvinceId == provinceId);
        }

        public Task<Community> GetCommunityByIdAsync(int id)
        {
            return FindAsync(id);
        }

        public Task<Community> GetCommunityByCodeAsync(string code)
        {
            return GetFirstAsync(community => community.Code == code);
        }
    }
}
