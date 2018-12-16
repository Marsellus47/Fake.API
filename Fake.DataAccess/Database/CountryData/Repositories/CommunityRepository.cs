using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class CommunityRepository : ReadWriteRepository<Community>, ICommunityRepository
    {
        public CommunityRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public Task<IEnumerable<Community>> GetCommunitiesAsync()
        {
            return GetAllAsync();
        }

        public async Task<IDictionary<int, Community>> GetCommunitiesAsync(IEnumerable<int> communityIds, CancellationToken token)
        {
            return await DbSet.Where(community => communityIds.Contains(community.Id))
                .ToDictionaryAsync(community => community.Id, token);
        }

        public Task<IEnumerable<Community>> GetCommunitiesByProvinceIdAsync(int provinceId)
        {
            return GetFilteredAsync(community => community.ProvinceId == provinceId);
        }

        public async Task<ILookup<int, Community>> GetCommunitiesByProvinceIdsAsync(IEnumerable<int> provinceIds)
        {
            var communities = await GetFilteredAsync(community => provinceIds.Contains(community.ProvinceId));
            return communities.ToLookup(community => community.ProvinceId);
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
