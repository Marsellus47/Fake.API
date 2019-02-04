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
    public class BooleansTests : RandomTestsBase
    {
        public BooleansTests(IdentityServerAuthenticationHostFixture hostFixture)
            : base(hostFixture) { }

        [Fact]
        public async Task ShouldFailWithoutCount()
        {
            // Arrange
            string query = "query { random { booleans } }";

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
    booleans(count:$count)
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
            random.Booleans.Count().Should().Equals(MIN_COUNT);
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
    booleans(count:$count)
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
            random.Booleans.Count().Should().Equals(MAX_COUNT);
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
    booleans(count:$count)
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
            random.Booleans.Count().Should().Equals(TEST_COUNT);
        }

        [Fact]
        public async Task ShouldGetOnlyFalseForZeroWeight()
        {
            // Arrange
            const int weight = 0;

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $weight:Float) {
  random {
    booleans(count:$count, weight:$weight)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    weight
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Should().OnlyContain(value => !value);
        }

        [Fact]
        public async Task ShouldGetMoreFalsesForLowerWeight()
        {
            // Arrange
            const float weight = 0.2F;

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $weight:Float) {
  random {
    booleans(count:$count, weight:$weight)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    weight
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Count(value => !value).Should().BeCloseTo((int)(TEST_COUNT * 0.8), 10);
            random.Booleans.Count(value => value).Should().BeCloseTo((int)(TEST_COUNT * 0.2), 10);
        }

        [Fact]
        public async Task ShouldGetOnlyTrueForOneWeight()
        {
            // Arrange
            const int weight = 1;

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $weight:Float) {
  random {
    booleans(count:$count, weight:$weight)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    weight
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Should().OnlyContain(value => value);
        }

        [Fact]
        public async Task ShouldGetMoreTruesForHigherWeight()
        {
            // Arrange
            const float weight = 0.8F;

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($count:Int!, $weight:Float) {
  random {
    booleans(count:$count, weight:$weight)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    count = TEST_COUNT,
                    weight
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Booleans.Count(value => value).Should().BeCloseTo((int)(TEST_COUNT * 0.8), 10);
            random.Booleans.Count(value => !value).Should().BeCloseTo((int)(TEST_COUNT * 0.2), 10);
        }
    }
}
