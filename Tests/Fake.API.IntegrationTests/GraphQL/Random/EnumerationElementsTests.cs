using Fake.API.IntegrationTests.Infrastructure;
using Fake.API.IntegrationTests.Infrastructure.IdentityServer;
using FluentAssertions;
using GraphQL.Common.Request;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    [Collection(WebHostHelper.IntegrationTestsWithIdentityServerCollectionName)]
    public class EnumerationElementsTests : RandomTestsBase
    {
        public EnumerationElementsTests(IdentityServerAuthenticationHostFixture hostFixture)
            : base(hostFixture) { }

        private IEnumerable<string> Items => new[] { "one", "two", "three", "four", "five" };
        public string FormattedItems => $"[{string.Join(", ", Items.Select(value => $"\"{value}\""))}]";

        [Fact]
        public async Task ShouldFailWithoutItems()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!) {
  random {
    enumerationElements(count:$count)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = 1
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("items") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($items:[String]!) {
  random {
    enumerationElements(items:$items)
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
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("count") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldGetHigherThanMinCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, MIN_COUNT - 1);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $items:[String!]!) {
  random {
    enumerationElements(count:$count, items:$items)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count,
                    items = Items
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElements.Count().Should().Equals(MIN_COUNT);
        }

        [Fact]
        public async Task ShouldFailWithCountHigherThanItemsCount()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $items:[String!]!) {
  random {
    enumerationElements(count:$count, items:$items)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = Items.Count() + 1,
                    items = Items
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("ArgumentOutOfRangeException"));
        }

        [Fact]
        public async Task ShouldGetCorrectCount()
        {
            // Arrange
            const short count = 2;

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $items:[String!]!) {
  random {
    enumerationElements(count:$count, items:$items)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count,
                    items = Items
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElements.Count().Should().Equals(count);
        }

        [Fact]
        public async Task ShouldGetEmptyResultForEmptyItems()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $items:[String!]!) {
  random {
    enumerationElements(count:$count, items:$items)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = 0,
                    items = new int[0]
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElements.Should().BeEmpty();
        }

        [Fact]
        public async Task ShouldGetElementsFromItems()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $items:[String!]!) {
  random {
    enumerationElements(count:$count, items:$items)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = Items.Count() - 2,
                    items = Items
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElements.Should().NotBeEmpty();
            random.EnumerationElements.Should().BeSubsetOf(Items);
        }
    }
}
