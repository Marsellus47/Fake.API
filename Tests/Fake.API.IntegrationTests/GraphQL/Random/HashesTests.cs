using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class HashesTests : RandomTestsBase
    {
        public HashesTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            string query = "query { random { hashes } }";

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
    hashes(count:$count)
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
            random.Hashes.Count().Should().Be(MIN_COUNT);
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
    hashes(count:$count)
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
            random.Hashes.Count().Should().Be(MAX_COUNT);
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
    hashes(count:$count)
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
            random.Hashes.Count().Should().Be(TEST_COUNT);
        }

        [Fact]
        public async Task ShouldGetDefaultLength()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!) {
  random {
    hashes(count:$count)
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
            random.Hashes.Should().OnlyContain(value => value.Length == 40);
        }

        [Fact]
        public async Task ShouldGetCorrectLength()
        {
            // Arrange
            short length = (short)RandomNumber(0, short.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $length:Int) {
  random {
    hashes(count:$count, length:$length)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    length
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Hashes.Should().OnlyContain(value => value.Length == length);
        }

        [Fact]
        public async Task ShouldGetDefaultUpperCase()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!) {
  random {
    hashes(count:$count)
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
            random.Hashes.Should().OnlyContain(value => value.ToCharArray()
                .Where(@char => char.IsLetter(@char))
                .All(@char => char.IsLower(@char)));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task ShouldGetCorrectUpperCase(bool upperCase)
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $upperCase:Boolean) {
  random {
    hashes(count:$count, upperCase:$upperCase)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    upperCase
                }
            };

            // Act
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Hashes.Should().OnlyContain(value => value.ToCharArray()
                .Where(@char => char.IsLetter(@char))
                .All(@char => upperCase ? char.IsUpper(@char) : char.IsLower(@char)));
        }

        [Fact]
        public async Task ShouldGetOnlyLettersAndDigits()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!) {
  random {
    hashes(count:$count)
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
            random.Hashes.Should().OnlyContain(value => value.ToCharArray().All(@char => char.IsLetterOrDigit(@char)));
        }
    }
}
