using Fake.Common.Extensions;
using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class DecimalsTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            string query = BuildQuery("decimals");

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
            string query = BuildQuery($"decimals(count:{count})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Count().Should().Equals(MIN_COUNT);
        }

        [Fact]
        public async Task ShouldGetLowerThanMaxCount()
        {
            // Arrange
            short count = (short)RandomNumber(MAX_COUNT + 1, short.MaxValue);
            string query = BuildQuery($"decimals(count:{count})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Count().Should().Equals(MAX_COUNT);
        }

        [Fact]
        public async Task ShouldGetCorrectCount()
        {
            // Arrange
            string query = BuildQuery($"decimals(count:{TEST_COUNT})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Count().Should().Equals(TEST_COUNT);
        }

        [Fact]
        public async Task ShouldGetBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = BuildQuery($"decimals(count:{TEST_COUNT})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Should().OnlyContain(value => value >= double.MinValue && value <= double.MaxValue);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.NextDouble(double.MinValue, double.MaxValue);
            string query = BuildQuery($"decimals(count:{TEST_COUNT}, min:{minValue.ToString(DecimalNumberFormatInfo)})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            var rand = new System.Random();
            double maxValue = rand.NextDouble(double.MinValue, double.MaxValue);
            string query = BuildQuery($"decimals(count:{TEST_COUNT}, max:{maxValue.ToString(DecimalNumberFormatInfo)})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxWhenInverted()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.NextDouble(30, 40);
            double maxValue = rand.NextDouble(10, 20);
            string query = BuildQuery($"decimals(count:{TEST_COUNT}, min:{minValue.ToString(DecimalNumberFormatInfo)}, max:{maxValue.ToString(DecimalNumberFormatInfo)})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Should().OnlyContain(value => value >= maxValue && value <= minValue);
        }
    }
}
