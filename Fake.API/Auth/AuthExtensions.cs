using Microsoft.Extensions.DependencyInjection;

namespace Fake.API.Auth
{
    public static class AuthExtensions
    {
        public static void AddFakeApiAuth(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                .AddInMemoryApiResources(Resources.GetApiResources())
                .AddTestUsers(Users.Get())
                .AddDeveloperSigningCredential();
        }
    }
}
