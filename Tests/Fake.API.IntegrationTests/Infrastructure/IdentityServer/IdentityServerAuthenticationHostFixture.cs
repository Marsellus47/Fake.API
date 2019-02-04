using System.Net.Http;
using Xunit;

namespace Fake.API.IntegrationTests.Infrastructure.IdentityServer
{
    public class IdentityServerAuthenticationHostFixture : ICollectionFixture<CustomWebAppFactoryWithIdentityServer>
    {
        public CustomWebAppFactoryWithIdentityServer Factory { get; }

        public IdentityServerAuthenticationHostFixture() => Factory = new CustomWebAppFactoryWithIdentityServer();

        public HttpClient GetClient(bool seedData)
            => Factory
                .WithWebHostBuilder(builder => builder.ConfigureDatabaseForIntegrationTesting(seedData))
                .CreateClient();
    }
}
