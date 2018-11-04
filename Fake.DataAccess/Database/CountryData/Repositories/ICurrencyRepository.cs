using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface ICurrencyRepository : IReadWriteRepository<Currency>
    {
        Task<IEnumerable<Currency>> GetCurrenciesAsync(int? pageNumber = null, int? pageSize = null);
        Task<IDictionary<int, Currency>> GetCurrenciesAsync(IEnumerable<int> currencyIds, CancellationToken token);
        Task<Currency> GetCurrencyByIdAsync(int id);
        Task<Currency> GetCurrencyByCodeAsync(string code);
    }
}
