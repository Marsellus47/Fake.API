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

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            return await _countryDataContext.Country.FirstOrDefaultAsync(country => country.Name == name);
        }
    }
}
