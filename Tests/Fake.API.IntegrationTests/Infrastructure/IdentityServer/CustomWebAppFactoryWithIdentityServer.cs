using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Fake.API.IntegrationTests.Infrastructure.IdentityServer
{
    public class CustomWebAppFactoryWithIdentityServer : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.Configure<IdentityServerAuthenticationOptions>(config =>
                {
                    config.Authority = IdentityServerSetup.Instance.IdentityServerUrl;
                    config.ApiName = "fake.api";
                    config.RequireHttpsMetadata = false;
                });
            });

            base.ConfigureWebHost(builder);
        }
    }
}
