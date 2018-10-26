using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class CountryType : ObjectGraphType<Country>
    {
        public CountryType(ICurrencyRepository currencyRepository, IStateRepository stateRepository)
        {
            Field(c => c.Id);
            Field(c => c.Name);
            Field(c => c.PostCodeRegex);
            Field(c => c.PostCodeFormat);
            Field(c => c.PhonePrefix);
            Field(c => c.TopLevelDomain);
            Field(c => c.Continent);
            Field(c => c.Area);
            Field(c => c.Capital);
            Field(c => c.Fips);
            Field(c => c.IsoNumeric, type: typeof(IntGraphType));
            Field(c => c.Iso3);
            Field(c => c.Iso);
            Field(c => c.Population, type: typeof(IntGraphType));
            Field<CurrencyType, Currency>()
                .Name("currency")
                .ResolveAsync(ctx => currencyRepository.GetCurrencyByIdAsync(ctx.Source.CurrencyId));
            Field<ListGraphType<StateType>, IEnumerable<State>>()
                .Name("states")
                .ResolveAsync(ctx => stateRepository.GetStatesByCountryIdAsync(ctx.Source.Id));
        }
    }
}
