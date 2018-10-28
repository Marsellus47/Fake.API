using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<IEnumerable<State>> GetStatesByCountryIdAsync(int countryId)
        {
            return GetFilteredAsync(state => state.CountryId == countryId);
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
