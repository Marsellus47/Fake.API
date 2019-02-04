using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Fake.API.IntegrationTests.Infrastructure.IdentityServer
{
    public class IdentityServerSetup
    {
        private IWebHost _webHost;
        private static IdentityServerSetup _instance;
        private static readonly object padlock = new object();
        private static List<TestUser> _users;

        public string IdentityServerUrl => "http://localhost:51641";
        private string TokenEndpoint => $"{IdentityServerUrl}/connect/token";

        private IdentityServerSetup() { }

        public static IdentityServerSetup Instance
        {
            get
            {
                lock(padlock)
                {
                    if(_instance == null)
                    {
                        _instance = new IdentityServerSetup();
                        _instance.InitializeIdentityServer();
                    }
                    return _instance;
                }
            }
        }

        public async Task<string> GetAccessTokenForUser(
            string username,
            string password,
            string clientId = "client",
            string clientSecret = "secret")
        {
            using (var client = new TokenClient(TokenEndpoint, clientId, clientSecret))
            {
                var response = await client.RequestResourceOwnerPasswordAsync(username, password, "fake.api");
                return response.AccessToken;
            }
        }

        private void InitializeIdentityServer()
        {
            _webHost = WebHost.CreateDefaultBuilder()
                .UseUrls(IdentityServerUrl)
                .ConfigureServices(services =>
                {
                    services.AddIdentityServer()
                        .AddDeveloperSigningCredential()
                        .AddInMemoryApiResources(GetApiResources())
                        .AddInMemoryClients(GetClients())
                        .AddTestUsers(GetUsers())
                        .AddProfileService<IdentityServerProfileService>();
                })
                .Configure(app => app.UseIdentityServer())
                .Build();
            Task.Factory.StartNew(() => _webHost.Run());
        }

        private static List<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API") {ApiSecrets = {new Secret("secret".Sha256())}},
                new ApiResource("fake.api", "Fake API")
            };
        }

        // Default client
        private static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1",
                        "fake.api"
                    },
                    AllowOfflineAccess = true
                }
            };
        }

        // Default user
        public static List<TestUser> GetUsers()
        {
            if (_users == null)
            {
                _users = new List<TestUser> {
                    new TestUser
                    {
                        SubjectId = Guid.NewGuid().ToString(),
                        Username = "user",
                        Password = "password",

                        Claims = new List<Claim>
                        {
                            new Claim("name", "User"),
                            new Claim("website", "https://user.com")
                        }
                    }
                };
            }

            return _users;
        }
    }
}
