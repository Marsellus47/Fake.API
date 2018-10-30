using Fake.DataAccess.Database.CountryData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<IDictionary<int, Country>> GetCountriesAsync(IEnumerable<int> countryIds, CancellationToken token);
        Task<IEnumerable<Country>> GetCountriesByLanguageIdAsync(int languageId);
        Task<ILookup<int, Country>> GetCountriesByLanguageIdsAsync(IEnumerable<int> languageIds);
        Task<Country> GetCountryByIdAsync(int id);
        Task<Country> GetCountryByNameAsync(string name);
    }
}
