using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Country>> GetCountriesByLanguageIdAsync(int languageId)
        {
            return await DbSet
                .Include(country => country.CountryLanguages)
                .SelectMany(country => country.CountryLanguages)
                .Where(countryLanguage => countryLanguage.LanguageId == languageId)
                .Select(countryLanguage => countryLanguage.Country)
                .ToListAsync();
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
