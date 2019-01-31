using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class DigitTests : RandomTestsBase
    {
        public DigitTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldGetBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = "query { random { digit } }";

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Digit.Should().BeInRange(byte.MinValue, 9);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            byte minValue = (byte)RandomNumber(byte.MinValue, 9);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:Int) {
  random {
    digit(min:$minValue)
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
            random.Digit.Should().BeGreaterOrEqualTo(minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            byte maxValue = (byte)RandomNumber(byte.MinValue, 9);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($maxValue:Int) {
  random {
    digit(max:$maxValue)
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
            random.Digit.Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxWhenInverted()
        {
            // Arrange
            byte minValue = (byte)RandomNumber(7, 9);
            byte maxValue = (byte)RandomNumber(byte.MinValue, 3);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:Int, $maxValue:Int) {
  random {
    digit(min:$minValue, max:$maxValue)
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
            random.Digit.Should().BeInRange(maxValue, minValue);
        }
    }
}
