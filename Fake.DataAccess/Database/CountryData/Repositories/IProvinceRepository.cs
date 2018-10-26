using Fake.DataAccess.Database.CountryData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<Province>> GetProvincesAsync();
        Task<IEnumerable<Province>> GetProvincesByStateIdAsync(int stateId);
        Task<Province> GetProvinceByIdAsync(int id);
        Task<Province> GetProvinceByCodeAsync(string code);
    }
}
