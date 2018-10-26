using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class StateType : ObjectGraphType<State>
    {
        public StateType(ICountryRepository countryRepository)
        {
            Field(state => state.Id);
            Field(state => state.Name);
            Field(state => state.Code);
            Field<CountryType, Country>()
                .Name("country")
                .ResolveAsync(context => countryRepository.GetCountryByIdAsync(context.Source.CountryId));
        }
    }
}
