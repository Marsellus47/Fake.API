using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(GraphQLQuery query)
        {
            Query = query;
        }
    }
}
