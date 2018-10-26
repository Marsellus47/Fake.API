using Fake.DataAccess.Database.CountryData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetStatesAsync();
        Task<IEnumerable<State>> GetStatesByCountryIdAsync(int countryId);
        Task<State> GetStateByCodeAsync(string code);
    }
}
