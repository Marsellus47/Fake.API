using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Models;
using IdentityServer4.Test;
using static IdentityServer4.IdentityServerConstants;

namespace Fake.API.IdentityServer
{
    internal static class Config
    {
        internal static IEnumerable<IdentityResource> GetIdentityResources()
            => new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> { "role" }
                }
            };

        internal static IEnumerable<ApiResource> GetApiResources()
            => new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "fake.api",
                    DisplayName = "Fake API",
                    Description = "Fake API Access",
                    UserClaims = new List<string> { "role" },
                    ApiSecrets = new List<Secret> { new Secret("scopeSecret".Sha256()) },
                    Scopes = new List<Scope>
                    {
                        new Scope("fake.api")
                    }
                }
            };

        internal static IEnumerable<Client> GetClients()
            => new List<Client>
            {
                new Client
                {
                    ClientId = "FakeAPIPostmanClient",
                    ClientName = "Fake API Web Client Hybrid",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        "fake.api"
                    },
                    AccessTokenLifetime = (int)System.TimeSpan.FromDays(30).TotalSeconds,
                    RedirectUris = { "https://www.getpostman.com/oauth2/callback" },
                    AllowAccessTokensViaBrowser = true
                }
            };

        internal static List<TestUser> GetUsers()
            => new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "78dda98b-3e80-43e2-a49f-8ca423f29ad8",
                    Username = "admin",
                    Password = "password",
                    Claims =
                    {
                        new Claim("name", "Admin"),
                        new Claim("role", "AdminRole")
                    }
                },
                new TestUser
                {
                    SubjectId = "103bbe82-85ea-4eea-b2d6-12f88f2370e6",
                    Username = "superadmin",
                    Password = "password",
                    Claims =
                    {
                        new Claim("name", "SuperAdmin"),
                        new Claim("role", "SuperAdminRole")
                    }
                }
            };
    }
}
