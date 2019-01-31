using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class CharsTests : RandomTestsBase
    {
        public CharsTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            string query = "query { random { chars } }";

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
    chars(count:$count)
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
            random.Chars.Count().Should().Equals(MIN_COUNT);
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
    chars(count:$count)
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
            random.Chars.Count().Should().Equals(MAX_COUNT);
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
    chars(count:$count)
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
            random.Chars.Count().Should().Equals(TEST_COUNT);
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
    chars(count:$count)
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
            random.Chars.Should().OnlyContain(value => value >= char.MinValue && value <= char.MaxValue);
        }

        [Fact]
        public async Task ShouldGetHigherThanMin()
        {
            // Arrange
            char minValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $minValue:String) {
  random {
    chars(count:$count, min:$minValue)
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
            random.Chars.Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public async Task ShouldGetLowerThanMax()
        {
            // Arrange
            char maxValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $maxValue:String) {
  random {
    chars(count:$count, max:$maxValue)
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
            random.Chars.Should().OnlyContain(value => value <= maxValue);
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
query myQuery($count:Int!, $minValue:String, $maxValue:String) {
  random {
    chars(count:$count, min:$minValue, max:$maxValue)
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
            random.Chars.Should().OnlyContain(value => value >= maxValue && value <= minValue);
        }
    }
}
