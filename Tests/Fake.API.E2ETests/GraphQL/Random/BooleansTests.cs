using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class BooleansTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            string query = BuildQuery("booleans");

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
            string query = BuildQuery($"booleans(count:{count})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Count().Should().Equals(MIN_COUNT);
        }

        [Fact]
        public async Task ShouldGetLowerThanMaxCount()
        {
            // Arrange
            short count = (short)RandomNumber(MAX_COUNT + 1, short.MaxValue);
            string query = BuildQuery($"booleans(count:{count})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Count().Should().Equals(MAX_COUNT);
        }

        [Fact]
        public async Task ShouldGetCorrectCount()
        {
            // Arrange
            string query = BuildQuery($"booleans(count:{TEST_COUNT})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Count().Should().Equals(TEST_COUNT);
        }

        [Fact]
        public async Task ShouldGetOnlyFalseForZeroWeight()
        {
            // Arrange
            const int weight = 0;
            string query = BuildQuery($"booleans(count:{TEST_COUNT}, weight:{weight})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Should().OnlyContain(value => !value);
        }

        [Fact]
        public async Task ShouldGetMoreFalsesForLowerWeight()
        {
            // Arrange
            const float weight = 0.2F;
            string query = BuildQuery($"booleans(count:{TEST_COUNT}, weight:{weight.ToString(DecimalNumberFormatInfo)})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Count(value => !value).Should().BeCloseTo((int)(TEST_COUNT * 0.8), 10);
            random.Booleans.Count(value => value).Should().BeCloseTo((int)(TEST_COUNT * 0.2), 10);
        }

        [Fact]
        public async Task ShouldGetOnlyTrueForOneWeight()
        {
            // Arrange
            const int weight = 1;
            string query = BuildQuery($"booleans(count:{TEST_COUNT}, weight:{weight})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Should().OnlyContain(value => value);
        }

        [Fact]
        public async Task ShouldGetMoreTruesForHigherWeight()
        {
            // Arrange
            const float weight = 0.8F;
            string query = BuildQuery($"booleans(count:{TEST_COUNT}, weight:{weight.ToString(DecimalNumberFormatInfo)})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Count(value => value).Should().BeCloseTo((int)(TEST_COUNT * 0.8), 10);
            random.Booleans.Count(value => !value).Should().BeCloseTo((int)(TEST_COUNT * 0.2), 10);
        }
    }
}
