using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class HashTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldGetDefaultLength()
        {
            // Arrange
            string query = BuildQuery("hash");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Hash.Length.Should().Be(40);
        }

        [Fact]
        public async Task ShouldGetCorrectLength()
        {
            // Arrange
            short length = (short)RandomNumber(0, short.MaxValue);
            string query = BuildQuery($"hash(length:{length})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Hash.Length.Should().Be(length);
        }

        [Fact]
        public async Task ShouldGetDefaultUpperCase()
        {
            // Arrange
            string query = BuildQuery("hash");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Hash.ToCharArray().Where(value => char.IsLetter(value)).Should().OnlyContain(value => char.IsLower(value));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task ShouldGetCorrectUpperCase(bool upperCase)
        {
            // Arrange
            string query = BuildQuery($"hash(upperCase:{upperCase.ToString().ToLower()})");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Hash.ToCharArray().Where(value => char.IsLetter(value)).Should().OnlyContain(value => upperCase ? char.IsUpper(value) : char.IsLower(value));
        }

        [Fact]
        public async Task ShouldGetOnlyLettersAndDigits()
        {
            // Arrange
            string query = BuildQuery("hash");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Hash.ToCharArray().Should().OnlyContain(value => char.IsLetterOrDigit(value));
        }
    }
}
