using Fake.API.IntegrationTests.Infrastructure;
using Fake.API.IntegrationTests.Infrastructure.IdentityServer;
using FluentAssertions;
using GraphQL.Common.Request;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    [Collection(WebHostHelper.IntegrationTestsWithIdentityServerCollectionName)]
    public class StringTests : RandomTestsBase
    {
        public StringTests(IdentityServerAuthenticationHostFixture hostFixture)
            : base(hostFixture) { }

        [Fact]
        public async Task ShouldGetLengthBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = "query { random { string } }";

            // Act
            var response = await AuthorizedClient.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.Length.Should().BeInRange(0, short.MaxValue);
        }

        [Fact]
        public async Task ShouldGetLengthHigherThanMin()
        {
            // Arrange
            short minValue = (short)RandomNumber(0, short.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:Int) {
  random {
    string(minLength:$minValue)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    minValue
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.Length.Should().BeGreaterOrEqualTo(minValue);
        }

        [Fact]
        public async Task ShouldGetLengthLowerThanMax()
        {
            // Arrange
            short maxValue = (short)RandomNumber(0, short.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($maxValue:Int) {
  random {
    string(maxLength:$maxValue)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    maxValue
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.Length.Should().BeLessOrEqualTo(maxValue);
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
    string(minLength:$minValue, maxLength:$maxValue)
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
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.Length.Should().BeInRange(maxValue, minValue);
        }

        [Fact]
        public async Task ShouldGetCharBetweenDefaultMinAndMax()
        {
            // Arrange
            string query = "query { random { string } }";

            // Act
            var response = await AuthorizedClient.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.ToCharArray().Should().OnlyContain(value => value >= char.MinValue && value <= char.MaxValue);
        }

        [Fact]
        public async Task ShouldGetCharHigherThanMin()
        {
            // Arrange
            char minValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:String) {
  random {
    string(minChar:$minValue)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    minValue
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.ToCharArray().Should().OnlyContain(value => value >= minValue);
        }

        [Fact]
        public async Task ShouldGetCharLowerThanMax()
        {
            // Arrange
            char maxValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($maxValue:String) {
  random {
    string(maxChar:$maxValue)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    maxValue
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.ToCharArray().Should().OnlyContain(value => value <= maxValue);
        }

        [Fact]
        public async Task ShouldSwitchMinAndMaxCharWhenInverted()
        {
            // Arrange
            char minValue = (char)RandomNumber('m', 'z');
            char maxValue = (char)RandomNumber('a', 'i');

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($minValue:String, $maxValue:String) {
  random {
    string(minChar:$minValue, maxChar:$maxValue)
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
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.String.ToCharArray().Should().OnlyContain(value => value >= maxValue && value <= minValue);
        }
    }
}
