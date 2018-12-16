using Fake.API.GraphQL.Types.CountryData.Input;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class FakeApiMutation : ObjectGraphType
    {
        public FakeApiMutation()
        {
            Field<CountryDataInputGroupGraphType>("countryData", resolve: context => new { });
        }
    }
}
