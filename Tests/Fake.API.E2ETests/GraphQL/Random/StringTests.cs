using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class StringTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldGetLengthBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = BuildQuery("string");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.Length.Should().BeInRange(0, short.MaxValue);
        }

        [Fact]
        public async Task ShouldGetLengthHigherThanMin()
        {
            // Arrange
            short minValue = (short)RandomNumber(0, short.MaxValue);
            string query = BuildQuery($"string(minLength:{minValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.Length.Should().BeGreaterOrEqualTo(minValue);
        }

        [Fact]
        public async Task ShouldGetLengthLowerThanMax()
        {
            // Arrange
            short maxValue = (short)RandomNumber(0, short.MaxValue);
            string query = BuildQuery($"string(maxLength:{maxValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.Length.Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxLengthWhenInverted()
        {
            // Arrange
            short minValue = (short)RandomNumber(30, 40);
            short maxValue = (short)RandomNumber(10, 20);
            string query = BuildQuery($"string(minLength:{minValue}, maxLength:{maxValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.Length.Should().BeInRange(maxValue, minValue);
        }

        [Fact]
        public async Task ShouldGetCharBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = BuildQuery("string");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.ToCharArray().Should().OnlyContain(value => value >= char.MinValue && value <= char.MaxValue);
        }

        [Fact]
        public async Task ShouldGetCharHigherThanMin()
        {
            // Arrange
            char minValue = (char)RandomNumber(char.MinValue, char.MaxValue);
            string query = BuildQuery($"string(minChar:\"{minValue}\")");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.ToCharArray().Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public async Task ShouldGetCharLowerThanMax()
        {
            // Arrange
            char maxValue = (char)RandomNumber(char.MinValue, char.MaxValue);
            string query = BuildQuery($"string(maxChar:\"{maxValue}\")");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.ToCharArray().Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxCharWhenInverted()
        {
            // Arrange
            char minValue = (char)RandomNumber('m', 'z');
            char maxValue = (char)RandomNumber('a', 'i');
            string query = BuildQuery($"string(minChar:\"{minValue}\", maxChar:\"{maxValue}\")");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.ToCharArray().Should().OnlyContain(value => value >= maxValue && value <= minValue);
        }
    }
}
