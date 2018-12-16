using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface IStateRepository : IReadWriteRepository<State>
    {
        Task<IEnumerable<State>> GetStatesAsync();
        Task<IDictionary<int, State>> GetStatesAsync(IEnumerable<int> stateIds, CancellationToken token);
        Task<IEnumerable<State>> GetStatesByCountryIdAsync(int countryId);
        Task<ILookup<int, State>> GetStatesByCountryIdsAsync(IEnumerable<int> countryIds);
        Task<State> GetStateByIdAsync(int id);
        Task<State> GetStateByCodeAsync(string code);
    }
}
