using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class EvenTests : RandomTestsBase
    {
        public EvenTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldGetBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = "query { random { even } }";

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Even.Should().BeInRange(int.MinValue, int.MaxValue);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            int minValue = (int)RandomNumber(int.MinValue, int.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:Int) {
  random {
    even(min:$minValue)
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
            random.Even.Should().BeGreaterOrEqualTo(minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            int maxValue = (int)RandomNumber(int.MinValue, int.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($maxValue:Int) {
  random {
    even(max:$maxValue)
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
            random.Even.Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public async Task ShouldGetEvenNumber()
        {
            // Arrange
            int minValue = (int)RandomNumber(int.MinValue, 1000);
            int maxValue = (int)RandomNumber(1001, int.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:Int, $maxValue:Int) {
  random {
    even(min:$minValue, max:$maxValue)
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
            (random.Even % 2).Should().Be(0);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxWhenInverted()
        {
            // Arrange
            int minValue = (int)RandomNumber(30, 40);
            int maxValue = (int)RandomNumber(10, 20);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:Int, $maxValue:Int) {
  random {
    even(min:$minValue, max:$maxValue)
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
            random.Even.Should().BeInRange(maxValue, minValue);
        }
    }
}
