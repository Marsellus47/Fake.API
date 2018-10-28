using Fake.DataAccess.Database.CountryData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface ICommunityRepository
    {
        Task<IEnumerable<Community>> GetCommunitiesAsync();
        Task<IEnumerable<Community>> GetCommunitiesByProvinceIdAsync(int provinceId);
        Task<Community> GetCommunityByIdAsync(int id);
        Task<Community> GetCommunityByCodeAsync(string code);
    }
}
