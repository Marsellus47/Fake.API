using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly CountryDataContext _countryDataContext;

        public StateRepository(CountryDataContext countryDataContext)
        {
            _countryDataContext = countryDataContext;
        }

        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            return await _countryDataContext.State.ToListAsync();
        }

        public async Task<IEnumerable<State>> GetStatesByCountryIdAsync(int countryId)
        {
            return await _countryDataContext.State.Where(state => state.CountryId == countryId).ToListAsync();
        }

        public Task<State> GetStateByIdAsync(int id)
        {
            return _countryDataContext.State.FindAsync(id);
        }

        public Task<State> GetStateByCodeAsync(string code)
        {
            return _countryDataContext.State.FirstOrDefaultAsync(state => state.Code == code);
        }
    }
}
