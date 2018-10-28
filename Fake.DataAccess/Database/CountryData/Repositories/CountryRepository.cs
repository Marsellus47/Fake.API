using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class CountryRepository : ReadOnlyRepository<Country>, ICountryRepository
    {
        public CountryRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return GetAllAsync();
        }

        public Task<Country> GetCountryByIdAsync(int id)
        {
            return FindAsync(id);
        }

        public Task<Country> GetCountryByNameAsync(string name)
        {
            return GetFirstAsync(country => country.Name == name);
        }
    }
}
