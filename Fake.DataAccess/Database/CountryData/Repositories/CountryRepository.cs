using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CountryDataContext _countryDataContext;

        public CountryRepository(CountryDataContext countryDataContext)
        {
            _countryDataContext = countryDataContext;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _countryDataContext.Country.ToListAsync();
        }

        public Task<Country> GetCountryByIdAsync(int id)
        {
            return _countryDataContext.Country.FindAsync(id);
        }

        public Task<Country> GetCountryByNameAsync(string name)
        {
            return _countryDataContext.Country.FirstOrDefaultAsync(country => country.Name == name);
        }
    }
}
