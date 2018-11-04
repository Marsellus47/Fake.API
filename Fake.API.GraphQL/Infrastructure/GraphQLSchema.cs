using GraphQL;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<GraphQLQuery>();
            Mutation = resolver.Resolve<GraphQLMutation>();
        }
    }
}
