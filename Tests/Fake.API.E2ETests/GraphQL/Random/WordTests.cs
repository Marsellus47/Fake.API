using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class WordTests : RandomTestsBase
    {
        [Fact]
        public async Task ShouldGetWord()
        {
            // Arrange
            string query = BuildQuery("word");

            // Act
            var response = await Client.SendQueryAsync(query);

            // Assert
            response.Errors.Should().BeNull();
            var random = ParseResponse(response);
            random.Word.Should().NotBeEmpty();
        }
    }
}
