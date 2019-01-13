using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class CountryRepository : ReadWriteRepository<Country>, ICountryRepository
    {
        public CountryRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return GetAllAsync();
        }

        public async Task<IDictionary<int, Country>> GetCountriesAsync(IEnumerable<int> countryIds, CancellationToken token)
        {
            return await DbSet.Where(country => countryIds.Contains(country.Id))
                .ToDictionaryAsync(country => country.Id, token);
        }

        public async Task<IEnumerable<Country>> GetCountriesByLanguageIdAsync(int languageId)
        {
            return await GetDbSet<CountryLanguage>()
                .Where(countryLanguage => countryLanguage.LanguageId == languageId)
                .Select(countryLanguage => countryLanguage.Country)
                .ToListAsync();
        }

        public async Task<ILookup<int, Country>> GetCountriesByLanguageIdsAsync(IEnumerable<int> languageIds)
        {
            var countries = await GetDbSet<CountryLanguage>()
                .Where(countryLanguage => languageIds.Contains(countryLanguage.LanguageId))
                .Include(countryLanguage => countryLanguage.Country)
                .ToListAsync();
            return countries.ToLookup(countryLanguage => countryLanguage.LanguageId, countryLanguage => countryLanguage.Country);
        }

        public async Task<ILookup<int, Country>> GetCountriesByCurrencyIdsAsync(IEnumerable<int> currencyIds)
        {
            var countries = await DbSet
                .Where(country => currencyIds.Contains(country.CurrencyId))
                .ToListAsync();
            return countries.ToLookup(countryLanguage => countryLanguage.CurrencyId);
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
