using Fake.API.IntegrationTests.Infrastructure;
using Fake.API.IntegrationTests.Infrastructure.IdentityServer;
using FluentAssertions;
using GraphQL.Common.Request;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    [Collection(WebHostHelper.IntegrationTestsWithIdentityServerCollectionName)]
    public class EnumerationElementTests : RandomTestsBase
    {
        public EnumerationElementTests(IdentityServerAuthenticationHostFixture hostFixture)
            : base(hostFixture) { }

        private IEnumerable<string> Items => new[] { "one", "two", "three", "four", "five" };

        [Fact]
        public async Task ShouldFailWithoutItems()
        {
            // Arrange
            string query = "query { random { enumerationElement } }";

            // Act
            var response = await AuthorizedClient.SendQueryAsync(query);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("items") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldGetNullForEmptyItems()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($items:[String!]!) {
  random {
    enumerationElement(items:$items)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    items = new int[0]
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElement.Should().BeNull();
        }

        [Fact]
        public async Task ShouldGetElementFromItems()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($items:[String!]!) {
  random {
    enumerationElement(items:$items)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    items = Items
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElement.Should().NotBeEmpty();
            Items.Should().Contain(random.EnumerationElement);
        }
    }
}
