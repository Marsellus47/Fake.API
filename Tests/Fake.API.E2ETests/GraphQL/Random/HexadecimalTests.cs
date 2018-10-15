using FluentAssertions;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class HexadecimalTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldGetHexadecimalNumber()
        {
            // Arrange
            string query = BuildQuery("hexadecimal");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            long.TryParse(random.Hexadecimal, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out long value).Should().BeTrue();
        }

        [Fact]
        public async Task ShouldGetBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = BuildQuery("hexadecimal");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            long.Parse(random.Hexadecimal, NumberStyles.HexNumber).Should().BeInRange(int.MinValue, int.MaxValue);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            int minValue = (int)RandomNumber(int.MinValue, int.MaxValue);
            string query = BuildQuery($"hexadecimal(min:{minValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            long.Parse(random.Hexadecimal, NumberStyles.HexNumber).Should().BeGreaterOrEqualTo(minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            int maxValue = (int)RandomNumber(int.MinValue, int.MaxValue);
            string query = BuildQuery($"hexadecimal(max:{maxValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            long.Parse(random.Hexadecimal, NumberStyles.HexNumber).Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxWhenInverted()
        {
            // Arrange
            int minValue = (int)RandomNumber(30, 40);
            int maxValue = (int)RandomNumber(10, 20);
            string query = BuildQuery($"hexadecimal(min:{minValue}, max:{maxValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            long.Parse(random.Hexadecimal, NumberStyles.HexNumber).Should().BeInRange(maxValue, minValue);
        }
    }
}
