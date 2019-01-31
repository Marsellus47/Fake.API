using GraphQL.Client.Http;
using GraphQL.Common.Response;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Globalization;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class RandomTestsBase : GraphQLTestsBase
    {
        protected const short MIN_COUNT = 1;
        protected const short MAX_COUNT = 1000;
        protected const short TEST_COUNT = MAX_COUNT / 10;

        protected RandomTestsBase(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        protected GraphQLHttpClient Client => GetGraphQLClient(false);

        protected RandomDTO ParseResponse(GraphQLResponse response)
            => response.GetDataFieldAs<RandomDTO>("random");
    }
}
