using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Fake.API.Auth
{
    public static class AuthExtensions
    {
        public static void AddFakeApiAuth(this IServiceCollection services)
        {
            var identityServerOptions = services.BuildServiceProvider().GetRequiredService<IOptions<IdentityServerAuthenticationOptions>>().Value;

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = identityServerOptions.Authority;
                    options.RequireHttpsMetadata = identityServerOptions.RequireHttpsMetadata;
                    options.ApiName = identityServerOptions.ApiName;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperAdmin", policy => policy.RequireClaim("role", "SuperAdminRole"));
            });
        }
    }
}
