using Fake.API.IntegrationTests.Infrastructure;
using FluentAssertions;
using GraphQL.Client.Http;
using GraphQL.Common.Response;
using Humanizer;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Text.RegularExpressions;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL
{
    public abstract class GraphQLTestsBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        protected GraphQLTestsBase(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        protected GraphQLHttpClient GetGraphQLClient(bool seedData = true)
            => factory
                .WithWebHostBuilder(builder => builder.ConfigureDatabaseForIntegrationTesting(seedData))
                .CreateClient()
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
    }
}
