using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface ILanguageRepository : IReadWriteRepository<Language>
    {
        Task<IEnumerable<Language>> GetLanguagesAsync();
        Task<IEnumerable<Language>> GetLanguagesByCountryIdAsync(int countryId);
        Task<ILookup<int, Language>> GetLanguagesByCountryIdsAsync(IEnumerable<int> countryIds);
        Task<Language> GetLanguageByCodeAsync(string code);
    }
}
