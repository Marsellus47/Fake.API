using Fake.Common.Extensions;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class DecimalTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldGetBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = BuildQuery("decimal");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimal.Should().BeInRange(double.MinValue, double.MaxValue);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.NextDouble(double.MinValue, double.MaxValue);
            string query = BuildQuery($"decimal(min:{minValue.ToString(DecimalNumberFormatInfo)})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimal.Should().BeGreaterOrEqualTo(minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            var rand = new System.Random();
            double maxValue = rand.NextDouble(int.MinValue, int.MaxValue);
            string query = BuildQuery($"decimal(max:{maxValue.ToString(DecimalNumberFormatInfo)})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimal.Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxWhenInverted()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.NextDouble(30, 40);
            double maxValue = rand.NextDouble(10, 20);
            string query = BuildQuery($"decimal(min:{minValue.ToString(DecimalNumberFormatInfo)}, max:{maxValue.ToString(DecimalNumberFormatInfo)})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimal.Should().BeInRange(maxValue, minValue);
        }
    }
}
