using System.Net.Http;
using GraphQL.Client.Http;

namespace Fake.API.IntegrationTests.Infrastructure
{
    public static class HttpClientExtensions
    {
        public static HttpClient WithAuthorization(this HttpClient client, string token)
        {
            string bearerTokenHeaderValue = $"Bearer {token}";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", bearerTokenHeaderValue);
            return client;
        }

        public static GraphQLHttpClient WithAuthorization(this GraphQLHttpClient client, string token)
        {
            string bearerTokenHeaderValue = $"Bearer {token}";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", bearerTokenHeaderValue);
            return client;
        }
    }
}
