using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData.Output
{
    public class StateType : ObjectGraphType<State>
    {
        public StateType(
            IDataLoaderContextAccessor accessor,
            ICountryRepository countryRepository,
            IProvinceRepository provinceRepository)
        {
            Field(state => state.Id, type: typeof(IdGraphType));
            Field(state => state.Name);
            Field(state => state.Code, nullable: true);
            Field<CountryType, Country>()
                .Name("country")
                .ResolveAsync(context =>
                {
                    var countryDataLoader = accessor.Context.GetOrAddBatchLoader<int, Country>(nameof(countryRepository.GetCountriesAsync), countryRepository.GetCountriesAsync);
                    return countryDataLoader.LoadAsync(context.Source.CountryId);
                });
            Field<ListGraphType<ProvinceType>, IEnumerable<Province>>()
                .Name("provinces")
                .ResolveAsync(context =>
                {
                    var provinceDataLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Province>(nameof(provinceRepository.GetProvincesByStateIdsAsync), provinceRepository.GetProvincesByStateIdsAsync);
                    return provinceDataLoader.LoadAsync(context.Source.Id);
                });
        }
    }
}
