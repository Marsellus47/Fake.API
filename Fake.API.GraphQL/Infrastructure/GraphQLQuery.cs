using Fake.API.GraphQL.Types;
using Fake.API.GraphQL.Types.CountryData;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class GraphQLQuery : ObjectGraphType
    {
        public GraphQLQuery()
        {
            Field<RandomGroupGraphType>("random", resolve: ctx => new { });
            Field<CountryDataGroupGraphType>("countryData", resolve: ctx => new { });
        }
    }
}
