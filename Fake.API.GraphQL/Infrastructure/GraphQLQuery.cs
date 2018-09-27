using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class GraphQLQuery : ObjectGraphType
    {
        public GraphQLQuery()
        {
            Field<StringGraphType>(
                name: "Hello",
                resolve: context => "World");
        }
    }
}
