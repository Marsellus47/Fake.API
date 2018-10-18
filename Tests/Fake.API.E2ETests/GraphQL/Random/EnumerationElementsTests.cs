using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class EnumerationElementsTests : RandomTestsBase
    {
        public IEnumerable<string> Items => new[] { "one", "two", "three", "four", "five" };
        public string FormattedItems => $"[{string.Join(", ", Items.Select(value => $"\"{value}\""))}]";

        [Fact]
        public async Task ShouldFailWithoutItems()
        {
            // Arrange
            string query = BuildQuery("enumerationElements(count:1)");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("items") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            string query = BuildQuery("enumerationElements(items:[])");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("count") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldGetHigherThanMinCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, MIN_COUNT - 1);
            string query = BuildQuery($"enumerationElements(count:{count}, items: {FormattedItems})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElements.Count().Should().Equals(MIN_COUNT);
        }

        [Fact]
        public async Task ShouldFailWithCountHigherThanItemsCount()
        {
            // Arrange
            string query = BuildQuery($"enumerationElements(count:{Items.Count() + 1}, items: {FormattedItems})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("ArgumentOutOfRangeException"));
        }

        [Fact]
        public async Task ShouldGetCorrectCount()
        {
            // Arrange
            const short count = 2;
            string query = BuildQuery($"enumerationElements(count:{count}, items: {FormattedItems})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElements.Count().Should().Equals(count);
        }

        [Fact]
        public async Task ShouldGetEmptyResultForEmptyItems()
        {
            // Arrange
            string query = BuildQuery("enumerationElements(count: 0, items:[])");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElements.Should().BeEmpty();
        }

        [Fact]
        public async Task ShouldGetElementsFromItems()
        {
            // Arrange
            string query = BuildQuery($"enumerationElements(count: {Items.Count() - 2}, items:{FormattedItems})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElements.Should().NotBeEmpty();
            random.EnumerationElements.Should().BeSubsetOf(Items);
        }
    }
}
