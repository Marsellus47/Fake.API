using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class CharTests : RandomTestsBase
    {
        public CharTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldGetBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = "query { random { char } }";

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Char.Should().BeInRange(char.MinValue, char.MaxValue);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            char minValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:String) {
  random {
    char(min:$minValue)
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
            random.Char.Should().BeGreaterOrEqualTo(minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            char maxValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($maxValue:String) {
  random {
    char(max:$maxValue)
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
            random.Char.Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxWhenInverted()
        {
            // Arrange
            char minValue = (char)RandomNumber('m', 'z');
            char maxValue = (char)RandomNumber('a', 'i');

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:String, $maxValue:String) {
  random {
    char(min:$minValue, max:$maxValue)
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
            random.Char.Should().BeInRange(maxValue, minValue);
        }
    }
}
