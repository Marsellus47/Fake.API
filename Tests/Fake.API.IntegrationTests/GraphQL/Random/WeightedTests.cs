using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class WeightedTests : RandomTestsBase
    {
        public WeightedTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        private IEnumerable<string> Items => new[] { "one", "two", "three", "four", "five" };
        private IEnumerable<float> Weights => new[] { 0F, 0F, 1F, 0F, 0F };

        [Fact]
        public async Task ShouldFailWithoutItems()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($weights:[Float!]!) {
  random {
    weighted(weights:$weights)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    Weights
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("items") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldFailWithoutWeights()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($items:[String!]!) {
  random {
    weighted(items:$items)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    Items
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("weights") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldGetNullForDifferentCountOfItemsAndWeights()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($items:[String!]!, $weights:[Float!]!) {
  random {
    weighted(items:$items, weights:$weights)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    Items,
                    weights = new[] { 0F, 1F }
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Weighted.Should().BeNull();
        }

        [Fact]
        public async Task ShouldGetNullForEmptyItems()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($items:[String!]!, $weights:[Float!]!) {
  random {
    weighted(items:$items, weights:$weights)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    items = new string[0],
                    weights = new float[0]
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Weighted.Should().BeNull();
        }

        [Fact]
        public async Task ShouldGetElementFromItems()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($items:[String!]!, $weights:[Float!]!) {
  random {
    weighted(items:$items, weights:$weights)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    Items,
                    Weights
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Weighted.Should().NotBeEmpty();
            Items.Should().Contain(random.Weighted);
        }

        [Fact]
        public async Task ShouldGetElementWithHighestWeight()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($items:[String!]!, $weights:[Float!]!) {
  random {
    weighted(items:$items, weights:$weights)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    Items,
                    Weights
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Weighted.Should().Be("three");
        }
    }
}
