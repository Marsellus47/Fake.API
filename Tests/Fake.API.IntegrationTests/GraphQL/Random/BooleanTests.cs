using Fake.API.IntegrationTests.Infrastructure;
using Fake.API.IntegrationTests.Infrastructure.IdentityServer;
using FluentAssertions;
using GraphQL.Common.Request;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    [Collection(WebHostHelper.IntegrationTestsWithIdentityServerCollectionName)]
    public class BooleanTests : RandomTestsBase
    {
        public BooleanTests(IdentityServerAuthenticationHostFixture hostFixture)
            : base(hostFixture) { }

        [Fact]
        public async Task ShouldGetBooleanValue()
        {
            // Arrange
            string query = "query { random { boolean } }";

            // Act
            var response = await AuthorizedClient.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Boolean.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldGetFalseForLowWeight()
        {
            // Arrange
            const int weight = 0;

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($weight:Float) {
  random {
    boolean(weight:$weight)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    weight
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Boolean.Should().BeFalse();
        }

        [Fact]
        public async Task ShouldGetTrueForHighWeight()
        {
            // Arrange
            const int weight = 1;

            var request = new GraphQLRequest
            {
                Query = @"
query myQuery($weight:Float) {
  random {
    boolean(weight:$weight)
  }
}",
                OperationName = "myQuery",
                Variables = new
                {
                    weight
                }
            };

            // Act
            var response = await AuthorizedClient.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Boolean.Should().BeTrue();
        }
    }
}
