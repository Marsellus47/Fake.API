using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class EnumerationElementTests : RandomTestsBase
    {
        public IEnumerable<string> Items => new[] { "one", "two", "three", "four", "five" };
        public string FormattedItems => $"[{string.Join(", ", Items.Select(value => $"\"{value}\""))}]";

        [Fact]
        public async Task ShouldFailWithoutItems()
        {
            // Arrange
            string query = BuildQuery("enumerationElement");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("items") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldGetNullForEmptyItems()
        {
            // Arrange
            string query = BuildQuery("enumerationElement(items:[])");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElement.Should().BeNull();
        }

        [Fact]
        public async Task ShouldGetElementFromItems()
        {
            // Arrange
            string query = BuildQuery($"enumerationElement(items:{FormattedItems})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.EnumerationElement.Should().NotBeEmpty();
            Items.Should().Contain(random.EnumerationElement);
        }
    }
}
