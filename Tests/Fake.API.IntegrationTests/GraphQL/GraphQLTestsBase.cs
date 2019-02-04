using Fake.API.IntegrationTests.Infrastructure.IdentityServer;
using Fake.Common.Extensions;
using FluentAssertions;
using GraphQL.Client.Http;
using GraphQL.Common.Response;
using Humanizer;
using System.Text.RegularExpressions;
using System;

namespace Fake.API.IntegrationTests.GraphQL
{
    public abstract class GraphQLTestsBase
    {
        private readonly IdentityServerAuthenticationHostFixture _hostFixture;

        protected GraphQLTestsBase(IdentityServerAuthenticationHostFixture hostFixture)
        {
            _hostFixture = hostFixture;
        }

        protected GraphQLHttpClient GetGraphQLClient(bool seedData = true)
            => _hostFixture
                    .GetClient(seedData)
                    .AsGraphQLClient(new GraphQLHttpClientOptions
                    {
                        EndPoint = new Uri("graphql", UriKind.Relative)
                    });

        protected void AssertMissingMandatoryField(GraphQLResponse response, string fieldName)
        {
            string pattern = $"In field \\\"{fieldName.Camelize()}\\\": Expected \\\"([a-z]|[A-Z])+!\\\", found null";
            response.Errors.Should().Contain(error => Regex.IsMatch(error.Message, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline));
        }

        protected void AssertNullSemiMandatoryField(GraphQLResponse response, string fieldName)
        {
            string errorMessage = $"{fieldName.Camelize()} cannot be null when listed, omit {fieldName.Camelize()} if you don't want to update it";
            response.Errors.Should().Contain(error => error.Message.IndexOf(errorMessage, StringComparison.InvariantCultureIgnoreCase) >= 0);
        }

        protected readonly Func<long, long, long> RandomNumber = (min, max)
            => new System.Random().NextLong(min, max);
    }
}
