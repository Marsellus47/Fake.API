using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class DigitTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldGetBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = BuildQuery("digit");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Digit.Should().BeInRange(byte.MinValue, 9);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            byte minValue = (byte)RandomNumber(byte.MinValue, 9);
            string query = BuildQuery($"digit(min:{minValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Digit.Should().BeGreaterOrEqualTo(minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            byte maxValue = (byte)RandomNumber(byte.MinValue, 9);
            string query = BuildQuery($"digit(max:{maxValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Digit.Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxWhenInverted()
        {
            // Arrange
            byte minValue = (byte)RandomNumber(7, 9);
            byte maxValue = (byte)RandomNumber(byte.MinValue, 3);
            string query = BuildQuery($"digit(min:{minValue}, max:{maxValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Digit.Should().BeInRange(maxValue, minValue);
        }
    }
}
