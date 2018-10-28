using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
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

        public Task<Language> GetLanguageByCodeAsync(string code)
        {
            return GetFirstAsync(language => language.Code == code);
        }
    }
}
