using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class LanguageType : ObjectGraphType<Language>
    {
        public LanguageType(IDataLoaderContextAccessor accessor, ICountryRepository countryRepository)
        {
            Field(c => c.Id);
            Field(c => c.Code);
            Field<ListGraphType<CountryType>, IEnumerable<Country>>()
                .Name("countries")
                .ResolveAsync(context =>
                {
                    var countryDataLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Country>(nameof(countryRepository.GetCountriesByLanguageIdsAsync), countryRepository.GetCountriesByLanguageIdsAsync);
                    return countryDataLoader.LoadAsync(context.Source.Id);
                });
        }
    }
}
