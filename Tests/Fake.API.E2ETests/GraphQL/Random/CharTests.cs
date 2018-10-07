using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class CharTests : RandomTestsBase
    {
        public async Task ShouldGetBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = BuildQuery("char");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Char.Should().BeInRange(char.MinValue, char.MaxValue);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            char minValue = (char)RandomNumber(char.MinValue, char.MaxValue);
            string query = BuildQuery($"char(min:\"{minValue}\")");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Char.Should().BeGreaterOrEqualTo(minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            char maxValue = (char)RandomNumber(char.MinValue, char.MaxValue);
            string query = BuildQuery($"char(max:\"{maxValue}\")");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Char.Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxWhenInverted()
        {
            // Arrange
            char minValue = (char)RandomNumber('m', 'z');
            char maxValue = (char)RandomNumber('a', 'i');
            string query = BuildQuery($"char(min:\"{minValue}\", max:\"{maxValue}\")");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Char.Should().BeInRange(maxValue, minValue);
        }
    }
}
