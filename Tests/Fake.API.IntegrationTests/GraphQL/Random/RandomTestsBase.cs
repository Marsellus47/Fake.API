using Fake.API.IntegrationTests.Infrastructure;
using Fake.API.IntegrationTests.Infrastructure.IdentityServer;
using GraphQL.Client.Http;
using GraphQL.Common.Response;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class RandomTestsBase : GraphQLTestsBase
    {
        protected const short MIN_COUNT = 1;
        protected const short MAX_COUNT = 1000;
        protected const short TEST_COUNT = MAX_COUNT / 10;

        protected RandomTestsBase(IdentityServerAuthenticationHostFixture hostFixture)
            : base(hostFixture) { }

        protected GraphQLHttpClient AuthorizedClient
            => UnauthorizedClient.WithAuthorization(IdentityServerSetup.Instance.GetAccessTokenForUser("user", "password").Result);

        protected GraphQLHttpClient UnauthorizedClient => GetGraphQLClient(false);

        protected RandomDTO ParseResponse(GraphQLResponse response)
            => response.GetDataFieldAs<RandomDTO>("random");
    }
}
