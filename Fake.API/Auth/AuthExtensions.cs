using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Fake.API.Auth
{
    public static class AuthExtensions
    {
        public static void AddFakeApiAuth(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients());

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:62095";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "fake.api";
                });

            services.AddAuthorization();
        }
    }
}
