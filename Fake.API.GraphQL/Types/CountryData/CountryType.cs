using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class CountryType : ObjectGraphType<Country>
    {
        public CountryType(
            IDataLoaderContextAccessor accessor,
            ICurrencyRepository currencyRepository,
            IStateRepository stateRepository,
            ILanguageRepository languageRepository)
        {
            Field(c => c.Id, type: typeof(IdGraphType));
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
                .ResolveAsync(context =>
                {
                    var currencyDataLoader = accessor.Context.GetOrAddBatchLoader<int, Currency>(nameof(currencyRepository.GetCurrenciesAsync), currencyRepository.GetCurrenciesAsync);
                    return currencyDataLoader.LoadAsync(context.Source.CurrencyId);
                });
            Field<ListGraphType<StateType>, IEnumerable<State>>()
                .Name("states")
                .ResolveAsync(context =>
                {
                    var stateDataLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, State>(nameof(stateRepository.GetStatesByCountryIdsAsync), stateRepository.GetStatesByCountryIdsAsync);
                    return stateDataLoader.LoadAsync(context.Source.Id);
                });
            Field<ListGraphType<LanguageType>, IEnumerable<Language>>()
                .Name("languages")
                .ResolveAsync(context =>
                {
                    var languageDataLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Language>(nameof(languageRepository.GetLanguagesByCountryIdsAsync), languageRepository.GetLanguagesByCountryIdsAsync);
                    return languageDataLoader.LoadAsync(context.Source.Id);
                });
        }
    }
}
