using GraphQL;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class FakeApiSchema : Schema
    {
        public FakeApiSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<FakeApiQuery>();
            Mutation = resolver.Resolve<FakeApiMutation>();
        }
    }
}
