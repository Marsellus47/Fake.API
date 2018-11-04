using Fake.API.GraphQL.Types;
using Fake.API.GraphQL.Types.CountryData.Output;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class GraphQLQuery : ObjectGraphType
    {
        public GraphQLQuery()
        {
            Field<RandomGroupGraphType>("random", resolve: context => new { });
            Field<CountryDataGroupGraphType>("countryData", resolve: context => new { });
        }
    }
}
