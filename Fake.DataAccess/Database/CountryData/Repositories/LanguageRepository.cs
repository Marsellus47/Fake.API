using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class LanguageRepository : ReadWriteRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            return GetAllAsync();
        }

        public async Task<IEnumerable<Language>> GetLanguagesByCountryIdAsync(int countryId)
        {
            return await GetDbSet<CountryLanguage>()
                .Where(countryLanguage => countryLanguage.CountryId == countryId)
                .Select(countryLanguage => countryLanguage.Language)
                .ToListAsync();
        }

        public async Task<ILookup<int, Language>> GetLanguagesByCountryIdsAsync(IEnumerable<int> countryIds)
        {
            var countryLanguages = await GetDbSet<CountryLanguage>()
                .Where(countryLanguage => countryIds.Contains(countryLanguage.CountryId))
                .Include(countryLanguage => countryLanguage.Language)
                .ToListAsync();
            return countryLanguages.ToLookup(countryLanguage => countryLanguage.CountryId, countryLanguage => countryLanguage.Language);
        }

        public Task<Language> GetLanguageByCodeAsync(string code)
        {
            return GetFirstAsync(language => language.Code == code);
        }
    }
}
