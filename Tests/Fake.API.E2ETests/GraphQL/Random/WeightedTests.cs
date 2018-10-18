using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class WeightedTests : RandomTestsBase
    {
        public IEnumerable<string> Items => new[] { "one", "two", "three", "four", "five" };
        public IEnumerable<float> Weights => new[] { 0F, 0F, 1F, 0F, 0F };
        public string FormattedItems => $"[{string.Join(", ", Items.Select(value => $"\"{value}\""))}]";
        public string FormatWeights(IEnumerable<float> weights) => $"[{string.Join(", ", weights.Select(value => value.ToString(DecimalNumberFormatInfo)))}]";

        [Fact]
        public async Task ShouldFailWithoutItems()
        {
            // Arrange
            string query = BuildQuery($"weighted(weights:{FormatWeights(Weights)})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("items") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldFailWithoutWeights()
        {
            // Arrange
            string query = BuildQuery($"weighted(items:{FormattedItems})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().NotBeNull();
            response.Errors.Should().Contain(error => error.Message.Contains("weights") && error.Message.Contains("required"));
        }

        [Fact]
        public async Task ShouldGetNullForDifferentCountOfItemsAndWeights()
        {
            // Arrange
            string query = BuildQuery($"weighted(items:{FormattedItems}, weights:{FormatWeights(new[] { 0F, 1F })})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Weighted.Should().BeNull();
        }

        [Fact]
        public async Task ShouldGetNullForEmptyItems()
        {
            // Arrange
            string query = BuildQuery("weighted(items:[], weights:[])");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Weighted.Should().BeNull();
        }

        [Fact]
        public async Task ShouldGetElementFromItems()
        {
            // Arrange
            string query = BuildQuery($"weighted(items:{FormattedItems}, weights:{FormatWeights(Weights)})");

            // Act
            var response = await Client.SendQueryAsync(query);

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
            string query = BuildQuery($"weighted(items:{FormattedItems}, weights:{FormatWeights(Weights)})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Weighted.Should().Be("three");
        }
    }
}
