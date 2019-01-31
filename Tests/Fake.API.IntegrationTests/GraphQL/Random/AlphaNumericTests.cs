using System.Threading.Tasks;
using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class AlphaNumericTests : RandomTestsBase
    {
        public AlphaNumericTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldGetLengthBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = "query { random { alphaNumeric } }";

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumeric.Length.Should().BeInRange(0, short.MaxValue);
        }

        [Fact]
        public async Task ShouldGetLengthHigherThanMin()
        {
            // Arrange
            short minValue = (short)RandomNumber(0, 1000);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:Int) {
  random {
    alphaNumeric(minLength:$minValue)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    minValue
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumeric.Length.Should().BeGreaterOrEqualTo(minValue);
        }

        [Fact]
        public async Task ShouldGetLengthLowerThanMax()
        {
            // Arrange
            short maxValue = (short)RandomNumber(0, 1000);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($maxValue:Int) {
  random {
    alphaNumeric(maxLength:$maxValue)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    maxValue
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumeric.Length.Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxLengthWhenInverted()
        {
            // Arrange
            short minValue = (short)RandomNumber(30, 40);
            short maxValue = (short)RandomNumber(10, 20);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:Int, $maxValue:Int) {
  random {
    alphaNumeric(minLength:$minValue, maxLength:$maxValue)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    minValue,
                    maxValue
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumeric.Length.Should().BeInRange(maxValue, minValue);
        }

        [Fact]
        public async Task ShouldGetOnlyAlphaNumericCharacters()
        {
            // Arrange
            string query = "query { random { alphaNumeric } }";

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumeric.Should().MatchRegex("^[a-zA-Z0-9]*$");
        }
    }
}
