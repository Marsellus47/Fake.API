using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class CurrencyType : ObjectGraphType<Currency>
    {
        public CurrencyType(IDataLoaderContextAccessor accessor, ICountryRepository countryRepository)
        {
            Field(c => c.Id, type: typeof(IdGraphType));
            Field(c => c.Name);
            Field(c => c.Code);
            Field<ListGraphType<CountryType>, IEnumerable<Country>>()
                .Name("countries")
                .ResolveAsync(context =>
                {
                    var countryDataLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Country>(nameof(countryRepository.GetCountriesByCurrencyIdsAsync), countryRepository.GetCountriesByCurrencyIdsAsync);
                    return countryDataLoader.LoadAsync(context.Source.Id);
                });
        }
    }
}
