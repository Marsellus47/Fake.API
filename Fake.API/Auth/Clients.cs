using System.Collections.Generic;
using IdentityServer4.Models;

namespace Fake.API.Auth
{
    // https://www.scottbrady91.com/Identity-Server/Getting-Started-with-IdentityServer-4
    internal class Clients
    {
        public static IEnumerable<Client> Get()
            => new List<Client>
            {
                new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example Client Credentials Client Application",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("superSecretPassword".Sha256())
                    },
                    AllowedScopes = new List<string> { "customAPI.read" }
                }
            };
    }
}
