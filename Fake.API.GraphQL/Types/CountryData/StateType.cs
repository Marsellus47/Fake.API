using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class StateType : ObjectGraphType<State>
    {
        public StateType(ICountryRepository countryRepository, IProvinceRepository provinceRepository)
        {
            Field(state => state.Id);
            Field(state => state.Name);
            Field(state => state.Code);
            Field<CountryType, Country>()
                .Name("country")
                .ResolveAsync(context => countryRepository.GetCountryByIdAsync(context.Source.CountryId));
            Field<ListGraphType<ProvinceType>, IEnumerable<Province>>()
                .Name("provinces")
                .ResolveAsync(ctx => provinceRepository.GetProvincesByStateIdAsync(ctx.Source.Id));
        }
    }
}
