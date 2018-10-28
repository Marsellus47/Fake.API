using Fake.DataAccess.Database.CountryData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<IEnumerable<Country>> GetCountriesByLanguageIdAsync(int languageId);
        Task<Country> GetCountryByIdAsync(int id);
        Task<Country> GetCountryByNameAsync(string name);
    }
}
