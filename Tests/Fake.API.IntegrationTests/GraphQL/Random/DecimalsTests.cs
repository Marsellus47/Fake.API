using Fake.Common.Extensions;
using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class DecimalsTests : RandomTestsBase
    {
        public DecimalsTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            string query = "query { random { decimals } }";

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

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!) {
  random {
    decimals(count:$count)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Count().Should().Equals(MIN_COUNT);
        }

        [Fact]
        public async Task ShouldGetLowerThanMaxCount()
        {
            // Arrange
            short count = (short)RandomNumber(MAX_COUNT + 1, short.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!) {
  random {
    decimals(count:$count)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Count().Should().Equals(MAX_COUNT);
        }

        [Fact]
        public async Task ShouldGetCorrectCount()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!) {
  random {
    decimals(count:$count)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Count().Should().Equals(TEST_COUNT);
        }

        [Fact]
        public async Task ShouldGetBetweenDefaultMinAndMax()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!) {
  random {
    decimals(count:$count)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Should().OnlyContain(value => value >= double.MinValue && value <= double.MaxValue);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.NextDouble(double.MinValue, double.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $minValue:Float) {
  random {
    decimals(count:$count, min:$minValue)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    minValue
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            var rand = new System.Random();
            double maxValue = rand.NextDouble(double.MinValue, double.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $maxValue:Float) {
  random {
    decimals(count:$count, max:$maxValue)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    maxValue
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxWhenInverted()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.NextDouble(30, 40);
            double maxValue = rand.NextDouble(10, 20);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $minValue:Float, $maxValue:Float) {
  random {
    decimals(count:$count, min:$minValue, max:$maxValue)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    minValue,
                    maxValue
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Decimals.Should().OnlyContain(value => value >= maxValue && value <= minValue);
        }
    }
}
