using Fake.Common.Extensions;
using GraphQL.Client.Http;
using GraphQL.Common.Response;
using System;

namespace Fake.API.E2ETests.GraphQL
{
    public abstract class GraphQLTestsBase<TResponse>
    {
        private const string SERVER_BASE_URL = "http://localhost:50765";
        private const string GRAPHQL_RESOURCE_URL = "/graphql";

        protected const short MIN_COUNT = 1;
        protected const short MAX_COUNT = 1000;
        protected const short TEST_COUNT = MAX_COUNT / 10;

        private GraphQLHttpClient _client;

        ~GraphQLTestsBase()
        {
            _client.Dispose();
            _client = null;
        }

        protected virtual string BuildQuery(string subQuery)
        {
            return $"query {{ {subQuery} }}";
        }

        protected GraphQLHttpClient Client
            => _client ?? (_client = new GraphQLHttpClient(SERVER_BASE_URL + GRAPHQL_RESOURCE_URL));

        protected readonly Func<long, long, long> RandomNumber = (min, max)
            => new System.Random().NextLong(min, max);

        protected abstract TResponse ParseResponse(GraphQLResponse response);
    }
}
