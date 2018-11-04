using GraphQL;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver dependencyResolver, GraphQLQuery query)
            : base(dependencyResolver)
        {
            Query = query;
        }
    }
}
