using Fake.API.IntegrationTests.Infrastructure;
using Fake.API.IntegrationTests.Infrastructure.IdentityServer;
using FluentAssertions;
using GraphQL.Common.Request;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    [Collection(WebHostHelper.IntegrationTestsWithIdentityServerCollectionName)]
    public class AlphaNumericsTests : RandomTestsBase
    {
        public AlphaNumericsTests(IdentityServerAuthenticationHostFixture hostFixture)
            : base(hostFixture) { }

        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            string query = "query { random { alphaNumerics } }";

            // Act
            var response = await AuthorizedClient.SendQueryAsync(query);

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
    alphaNumerics(count:$count)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumerics.Count().Should().Equals(MIN_COUNT);
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
    alphaNumerics(count:$count)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumerics.Count().Should().Equals(MAX_COUNT);
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
    alphaNumerics(count:$count)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumerics.Count().Should().Equals(TEST_COUNT);
        }

        [Fact]
        public async Task ShouldGetLengthBetweenDefaultMinAndMax()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!) {
  random {
    alphaNumerics(count:$count)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumerics.Should().OnlyContain(value => value.Length <= short.MaxValue);
        }

        [Fact]
        public async Task ShouldGetLengthHigherThanMin()
        {
            // Arrange
            short minValue = (short)RandomNumber(0, 1000);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $minLength:Int) {
  random {
    alphaNumerics(count:$count, minLength:$minLength)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    minLength = minValue
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumerics.Should().OnlyContain(value => value.Length >= minValue);
        }

        [Fact]
        public async Task ShouldGetLengthLowerThanMax()
        {
            // Arrange
            short maxValue = (short)RandomNumber(0, 1000);

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $maxLength:Int) {
  random {
    alphaNumerics(count:$count, maxLength:$maxLength)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    maxLength = maxValue
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumerics.Should().OnlyContain(value => value.Length <= maxValue);
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
query myQuery($count:Int!, $minLength:Int, $maxLength:Int) {
  random {
    alphaNumerics(count:$count, minLength:$minLength, maxLength:$maxLength)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    minLength = minValue,
                    maxLength = maxValue
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumerics.Should().OnlyContain(value => value.Length >= maxValue && value.Length <= minValue);
        }

        [Fact]
        public async Task ShouldGetOnlyAlphaNumericCharacters()
        {
            // Arrange
            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!) {
  random {
    alphaNumerics(count:$count)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.AlphaNumerics.Should().OnlyContain(value => new Regex("^[a-zA-Z0-9]*$").Match(value).Success);
        }
    }
}
