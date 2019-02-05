using Fake.API.GraphQL.Types.Random.Output;
using Fake.API.GraphQL.Types.CountryData.Output;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class FakeApiQuery : ObjectGraphType
    {
        public FakeApiQuery()
        {
            Field<RandomOutputGroupGraphType>("random", resolve: context => new { }).RequirePermission("");
            Field<CountryDataOutputGroupGraphType>("countryData", resolve: context => new { });
        }
    }
}
