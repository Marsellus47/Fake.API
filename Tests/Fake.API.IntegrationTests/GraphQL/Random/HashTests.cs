using Fake.API.IntegrationTests.Infrastructure;
using Fake.API.IntegrationTests.Infrastructure.IdentityServer;
using FluentAssertions;
using GraphQL.Common.Request;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    [Collection(WebHostHelper.IntegrationTestsWithIdentityServerCollectionName)]
    public class HashTests : RandomTestsBase
    {
        public HashTests(IdentityServerAuthenticationHostFixture hostFixture)
            : base(hostFixture) { }

        [Fact]
        public async Task ShouldGetDefaultLength()
        {
            // Arrange
            string query = "query { random { hash } }";

            // Act
            var response = await AuthorizedClient.SendQueryAsync(query);

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

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($length:Int) {
  random {
    hash(length:$length)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    length
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Hash.Length.Should().Be(length);
        }

        [Fact]
        public async Task ShouldGetDefaultUpperCase()
        {
            // Arrange
            string query = "query { random { hash } }";

            // Act
            var response = await AuthorizedClient.SendQueryAsync(query);

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
            //string query = BuildQuery($"hash(upperCase:{upperCase.ToString().ToLower()})");

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($upperCase:Boolean) {
  random {
    hash(upperCase:$upperCase)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    upperCase
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Hash.ToCharArray().Where(value => char.IsLetter(value)).Should().OnlyContain(value => upperCase ? char.IsUpper(value) : char.IsLower(value));
        }

        [Fact]
        public async Task ShouldGetOnlyLettersAndDigits()
        {
            // Arrange
            string query = "query { random { hash } }";

            // Act
            var response = await AuthorizedClient.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Hash.ToCharArray().Should().OnlyContain(value => char.IsLetterOrDigit(value));
        }
    }
}
