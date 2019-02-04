using Xunit;

namespace Fake.API.IntegrationTests.Infrastructure.IdentityServer
{
    [CollectionDefinition(WebHostHelper.IntegrationTestsWithIdentityServerCollectionName)]
    public class IdentityServerAuthenticationIntegrationTestsCollection : ICollectionFixture<IdentityServerAuthenticationHostFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
