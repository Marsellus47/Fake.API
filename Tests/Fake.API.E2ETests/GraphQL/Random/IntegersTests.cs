using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class IntegersTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, MIN_COUNT - 1);
            string query = BuildQuery("integers");

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
            string query = BuildQuery($"integers(count:{count})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = GetRandom(response);
            random.Integers.Count().Should().Equals(MIN_COUNT);
        }

        [Fact]
        public async Task ShouldGetLowerThanMaxCount()
        {
            // Arrange
            short count = (short)RandomNumber(MIN_COUNT + 1, short.MaxValue);
            string query = BuildQuery($"integers(count:{count})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = GetRandom(response);
            random.Integers.Count().Should().Equals(MAX_COUNT);
        }

        [Fact]
        public async Task ShouldGetCorrectCount()
        {
            // Arrange
            string query = BuildQuery($"integers(count:{TEST_COUNT})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = GetRandom(response);
            random.Integers.Count().Should().Equals(TEST_COUNT);
        }

        [Fact]
        public async Task ShouldGetBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = BuildQuery($"integers(count:{TEST_COUNT})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = GetRandom(response);
            random.Integers.Should().OnlyContain(value => value >= int.MinValue && value <= int.MaxValue);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            int minValue = (int)RandomNumber(int.MinValue, int.MaxValue);
            string query = BuildQuery($"integers(count:{TEST_COUNT}, min:{minValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = GetRandom(response);
            random.Integers.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            int maxValue = (int)RandomNumber(int.MinValue, int.MaxValue);
            string query = BuildQuery($"integers(count:{TEST_COUNT}, max:{maxValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = GetRandom(response);
            random.Integers.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxWhenInverted()
        {
            // Arrange
            int minValue = (int)RandomNumber(30, 40);
            int maxValue = (int)RandomNumber(10, 20);
            string query = BuildQuery($"integers(count:{TEST_COUNT}, min:{minValue}, max:{maxValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = GetRandom(response);
            random.Integers.Should().OnlyContain(value => value >= int.MinValue && value <= int.MaxValue);
        }
    }
}
