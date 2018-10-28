using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class CurrencyRepository : ReadOnlyRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public Task<IEnumerable<Currency>> GetCurrenciesAsync()
        {
            return GetAllAsync();
        }

        public Task<Currency> GetCurrencyByIdAsync(int id)
        {
            return FindAsync(id);
        }

        public Task<Currency> GetCurrencyByCodeAsync(string code)
        {
            return GetFirstAsync(currency => currency.Code == code);
        }
    }
}
