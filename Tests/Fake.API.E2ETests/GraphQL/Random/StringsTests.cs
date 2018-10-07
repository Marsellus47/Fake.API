using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class StringsTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            string query = BuildQuery("strings");

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
            string query = BuildQuery($"strings(count:{count})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Count().Should().Equals(MIN_COUNT);
        }

        [Fact]
        public async Task ShouldGetLowerThanMaxCount()
        {
            // Arrange
            short count = (short)RandomNumber(MAX_COUNT + 1, short.MaxValue);
            string query = BuildQuery($"strings(count:{count})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Count().Should().Equals(MAX_COUNT);
        }

        [Fact]
        public async Task ShouldGetCorrectCount()
        {
            // Arrange
            string query = BuildQuery($"strings(count:{TEST_COUNT})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Count().Should().Equals(TEST_COUNT);
        }

        [Fact]
        public async Task ShouldGetLengthBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = BuildQuery($"strings(count:{TEST_COUNT})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Should().OnlyContain(value => value.Length <= short.MaxValue);
        }

        [Fact]
        public async Task ShouldGetLengthHigherThanMin()
        {
            // Arrange
            short minValue = (short)RandomNumber(0, short.MaxValue);
            string query = BuildQuery($"strings(count:{TEST_COUNT}, minLength:{minValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Should().OnlyContain(value => value.Length >= minValue);
        }

        [Fact]
        public async Task ShouldGetLengthLowerThanMax()
        {
            // Arrange
            short maxValue = (short)RandomNumber(0, short.MaxValue);
            string query = BuildQuery($"strings(count:{TEST_COUNT}, maxLength:{maxValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Should().OnlyContain(value => value.Length <= maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxLengthWhenInverted()
        {
            // Arrange
            short minValue = (short)RandomNumber(30, 40);
            short maxValue = (short)RandomNumber(10, 20);
            string query = BuildQuery($"strings(count:{TEST_COUNT}, minLength:{minValue}, maxLength:{maxValue})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Should().OnlyContain(value => value.Length >= maxValue && value.Length <= minValue);
        }

        [Fact]
        public async Task ShouldGetCharBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = BuildQuery($"strings(count:{TEST_COUNT})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Should().OnlyContain(value => value.ToCharArray().All(@char => @char >= char.MinValue && @char <= char.MaxValue));
        }

        [Fact]
        public async Task ShouldGetCharHigherThanMin()
        {
            // Arrange
            char minValue = (char)RandomNumber(char.MinValue, char.MaxValue);
            string query = BuildQuery($"strings(count:{TEST_COUNT}, minChar:\"{minValue}\")");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Should().OnlyContain(value => value.ToCharArray().All(@char => @char >= minValue));
        }

        [Fact]
        public async Task ShouldGetCharLowerThanMax()
        {
            // Arrange
            char maxValue = (char)RandomNumber(char.MinValue, char.MaxValue);
            string query = BuildQuery($"strings(count:{TEST_COUNT}, maxChar:\"{maxValue}\")");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Should().OnlyContain(value => value.ToCharArray().All(@char => @char <= maxValue));
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxCharWhenInverted()
        {
            // Arrange
            char minValue = (char)RandomNumber('m', 'z');
            char maxValue = (char)RandomNumber('a', 'i');
            string query = BuildQuery($"strings(count:{TEST_COUNT}, minChar:\"{minValue}\", maxChar:\"{maxValue}\")");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Strings.Select(value => value.ToCharArray().Should().OnlyContain(@char => @char >= maxValue && @char <= minValue));
        }
    }
}
