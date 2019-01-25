using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Fake.API.Auth
{
    public static class AuthExtensions
    {
        public static void AddFakeApiAuth(this IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:51641";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "fake.api";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperAdmin", policy => policy.RequireClaim("role", "SuperAdminRole"));
            });
        }
    }
}
