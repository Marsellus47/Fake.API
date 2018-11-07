using Fake.API.GraphQL.Types.CountryData.Input;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class GraphQLMutation : ObjectGraphType
    {
        public GraphQLMutation()
        {
            Field<CountryDataInputGroupGraphType>("countryData", resolve: context => new { });
        }
    }
}
