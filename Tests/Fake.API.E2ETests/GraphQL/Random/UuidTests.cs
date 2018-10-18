using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class UuidTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldGetUuid()
        {
            // Arrange
            string query = BuildQuery("uuid");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Uuid.Should().NotBeEmpty();
        }
    }
}
