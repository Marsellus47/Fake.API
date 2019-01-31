using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class ShuffleTests : RandomTestsBase
    {
        public ShuffleTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        private IEnumerable<string> Items => new[] { "one", "two", "three", "four", "five" };
        public string FormattedItems => $"[{string.Join(", ", Items.Select(value => $"\"{value}\""))}]";

        [Fact]
        public async Task ShouldFailWithoutItems()
        {
            // Arrange
            string query = "query { random { shuffle } }";

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("items") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldGetEmptyForEmptyItems()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($items:[String!]!) {
  random {
    shuffle(items:$items)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    items = new string[0]
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Shuffle.Should().BeEmpty();
        }

        [Fact]
        public async Task ShouldGetAllElementsFromItems()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($items:[String!]!) {
  random {
    shuffle(items:$items)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    items = Items
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Shuffle.Should().NotBeEmpty();
            Items.Should().IntersectWith(random.Shuffle);
            Items.Should().HaveSameCount(random.Shuffle);
        }
    }
}
