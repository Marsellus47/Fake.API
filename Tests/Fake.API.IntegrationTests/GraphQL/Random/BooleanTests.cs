using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Random
{
    public class BooleanTests : RandomTestsBase
    {
        public BooleanTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldGetBooleanValue()
        {
            // Arrange
            string query = "query { random { boolean } }";

            // Act
            var response = await Client.SendQueryAsync(query);

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
            var response = await Client.SendQueryAsync(request);

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
            var response = await Client.SendQueryAsync(request);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Boolean.Should().BeTrue();
        }
    }
}
