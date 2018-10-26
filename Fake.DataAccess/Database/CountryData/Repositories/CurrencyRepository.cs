using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CountryDataContext _countryDataContext;

        public CurrencyRepository(CountryDataContext countryDataContext)
        {
            _countryDataContext = countryDataContext;
        }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync()
        {
            return await _countryDataContext.Currency.ToListAsync();
        }

        public Task<Currency> GetCurrencyByIdAsync(int id)
        {
            return _countryDataContext.Currency.FindAsync(id);
        }

        public Task<Currency> GetCurrencyByCodeAsync(string code)
        {
            return _countryDataContext.Currency.FirstOrDefaultAsync(currency => currency.Code == code);
        }
    }
}
