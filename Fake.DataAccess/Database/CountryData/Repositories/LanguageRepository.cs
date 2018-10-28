using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class LanguageRepository : ReadOnlyRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            return GetAllAsync();
        }

        public async Task<IEnumerable<Language>> GetLanguagesByCountryIdAsync(int countryId)
        {
            return await DbSet
                .Include(language => language.CountryLanguages)
                .SelectMany(language => language.CountryLanguages)
                .Where(countryLanguage => countryLanguage.CountryId == countryId)
                .Select(countryLanguage => countryLanguage.Language)
                .ToListAsync();
        }

        public Task<Language> GetLanguageByCodeAsync(string code)
        {
            return GetFirstAsync(language => language.Code == code);
        }
    }
}
