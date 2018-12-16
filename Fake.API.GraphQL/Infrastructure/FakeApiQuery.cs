using Fake.API.GraphQL.Types;
using Fake.API.GraphQL.Types.CountryData.Output;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class FakeApiQuery : ObjectGraphType
    {
        public FakeApiQuery()
        {
            Field<RandomGroupGraphType>("random", resolve: context => new { });
            Field<CountryDataOutputGroupGraphType>("countryData", resolve: context => new { });
        }
    }
}
