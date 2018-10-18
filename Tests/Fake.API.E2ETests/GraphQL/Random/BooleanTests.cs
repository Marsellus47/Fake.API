using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class BooleanTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldGetBooleanValue()
        {
            // Arrange
            string query = BuildQuery("boolean");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Boolean.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldGetFalseForLowWeight()
        {
            // Arrange
            const int weight = 0;
            string query = BuildQuery($"boolean(weight:{weight})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Boolean.Should().BeFalse();
        }

        [Fact]
        public async Task ShouldGetTrueForHighWeight()
        {
            // Arrange
            const int weight = 1;
            string query = BuildQuery($"boolean(weight:{weight})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Boolean.Should().BeTrue();
        }
    }
}
