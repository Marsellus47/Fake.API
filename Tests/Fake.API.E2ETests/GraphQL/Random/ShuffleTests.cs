using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class ShuffleTests : RandomTestsBase
    {
        public IEnumerable<string> Items => new[] { "one", "two", "three", "four", "five" };
        public string FormattedItems => $"[{string.Join(", ", Items.Select(value => $"\"{value}\""))}]";

        [Fact]
        public async Task ShouldFailWithoutItems()
        {
            // Arrange
            string query = BuildQuery("shuffle");

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
            string query = BuildQuery("shuffle(items:[])");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Shuffle.Should().BeEmpty();
        }

        [Fact]
        public async Task ShouldGetAllElementsFromItems()
        {
            // Arrange
            string query = BuildQuery($"shuffle(items:{FormattedItems})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Shuffle.Should().NotBeEmpty();
            Items.Should().IntersectWith(random.Shuffle);
            Items.Should().HaveSameCount(random.Shuffle);
        }
    }
}
