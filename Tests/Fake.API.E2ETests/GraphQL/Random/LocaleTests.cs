using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class LocaleTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldGetLocale()
        {
            // Arrange
            string query = BuildQuery("locale");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Locale.Should().NotBeEmpty();
        }
    }
}
