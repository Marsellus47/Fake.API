﻿using Fake.DataAccess.Database.CountryData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetCurrenciesAsync(int? pageNumber = null, int? pageSize = null);
        Task<Currency> GetCurrencyByIdAsync(int id);
        Task<Currency> GetCurrencyByCodeAsync(string code);
    }
}
