using Fake.Common.Extensions;
using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class CurrencyRepository : ReadOnlyRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync(int? pageNumber = null, int? pageSize = null)
        {
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                return await DbSet.AsQueryable()
                    .Paginate(pageNumber.Value, pageSize.Value)
                    .ToListAsync();
            }

            return await GetAllAsync();
        }

        public async Task<IDictionary<int, Currency>> GetCurrenciesAsync(IEnumerable<int> currencyIds, CancellationToken token)
        {
            return await DbSet.Where(currency => currencyIds.Contains(currency.Id))
                .ToDictionaryAsync(currency => currency.Id, token);
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
