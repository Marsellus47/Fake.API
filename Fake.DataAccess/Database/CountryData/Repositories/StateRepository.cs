using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class StateRepository : ReadOnlyRepository<State>, IStateRepository
    {
        public StateRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public Task<IEnumerable<State>> GetStatesAsync()
        {
            return GetAllAsync();
        }

        public async Task<IDictionary<int, State>> GetStatesAsync(IEnumerable<int> stateIds, CancellationToken token)
        {
            return await DbSet.Where(state => stateIds.Contains(state.Id))
                .ToDictionaryAsync(state => state.Id, token);
        }

        public Task<IEnumerable<State>> GetStatesByCountryIdAsync(int countryId)
        {
            return GetFilteredAsync(state => state.CountryId == countryId);
        }

        public async Task<ILookup<int, State>> GetStatesByCountryIdsAsync(IEnumerable<int> countryIds)
        {
            var states = await GetFilteredAsync(state => countryIds.Contains(state.CountryId));
            return states.ToLookup(state => state.CountryId);
        }

        public Task<State> GetStateByIdAsync(int id)
        {
            return FindAsync(id);
        }

        public Task<State> GetStateByCodeAsync(string code)
        {
            return GetFirstAsync(state => state.Code == code);
        }
    }
}
