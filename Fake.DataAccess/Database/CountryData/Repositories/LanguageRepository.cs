using System.Collections.Generic;
using System.Threading.Tasks;
using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly CountryDataContext _countryDataContext;

        public LanguageRepository(CountryDataContext countryDataContext)
        {
            _countryDataContext = countryDataContext;
        }

        public Task<Language> GetLanguageByCodeAsync(string code)
        {
            return _countryDataContext.Language.FirstOrDefaultAsync(language => language.Code == code);
        }

        public async Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            return await _countryDataContext.Language.ToListAsync();
        }
    }
}
