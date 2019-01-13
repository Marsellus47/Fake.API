using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface ICountryRepository : IReadWriteRepository<Country>
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<IDictionary<int, Country>> GetCountriesAsync(IEnumerable<int> countryIds, CancellationToken token);
        Task<IEnumerable<Country>> GetCountriesByLanguageIdAsync(int languageId);
        Task<ILookup<int, Country>> GetCountriesByLanguageIdsAsync(IEnumerable<int> languageIds);
        Task<ILookup<int, Country>> GetCountriesByCurrencyIdsAsync(IEnumerable<int> currencyIds);
        Task<Country> GetCountryByIdAsync(int id);
        Task<Country> GetCountryByNameAsync(string name);
    }
}
