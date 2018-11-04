using Fake.DataAccess.Database.CountryData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface ICommunityRepository
    {
        Task<IEnumerable<Community>> GetCommunitiesAsync();
        Task<IDictionary<int, Community>> GetCommunitiesAsync(IEnumerable<int> communityIds, CancellationToken token);
        Task<IEnumerable<Community>> GetCommunitiesByProvinceIdAsync(int provinceId);
        Task<ILookup<int, Community>> GetCommunitiesByProvinceIdsAsync(IEnumerable<int> provinceIds);
        Task<Community> GetCommunityByIdAsync(int id);
        Task<Community> GetCommunityByCodeAsync(string code);
    }
}
