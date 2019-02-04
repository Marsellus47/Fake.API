using Fake.API.IntegrationTests.Infrastructure;
using Fake.API.IntegrationTests.Infrastructure.IdentityServer;
using FluentAssertions;
using GraphQL.Common.Request;
using System.Threading.Tasks;
using Xunit;

namespace Fake.API.IntegrationTests.GraphQL.Mutation.CountryData.Currency
{
    [Collection(WebHostHelper.IntegrationTestsWithIdentityServerCollectionName)]
    public class DeleteTests : GraphQLTestsBase
    {
        public DeleteTests(IdentityServerAuthenticationHostFixture hostFixture)
            : base(hostFixture) { }

        [Fact]
        public async Task ShouldDeleteExistingCurrency()
        {
            // Arrange
            var client = GetGraphQLClient(true)
                .WithAuthorization(IdentityServerSetup.Instance.GetAccessTokenForUser("user", "password").Result);

            const int id = 1;

            var deleteCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($id:ID!) {
  countryData {
    currency {
      delete(id:$id)
    }
  }
}",
                OperationName = "myMutation",
                Variables = new
                {
                    id
                }
            };

            // Act
            var response = await client.SendMutationAsync(deleteCurrencyRequest);

            // Assert
            response.Errors.Should().BeNull();
            bool deleted = response.Data.countryData.currency.delete;
            deleted.Should().BeTrue();
        }

        [Fact]
        public async Task ShouldNotDeleteMissingCurrency()
        {
            // Arrange
            var client = GetGraphQLClient(false)
                .WithAuthorization(IdentityServerSetup.Instance.GetAccessTokenForUser("user", "password").Result);

            const int id = 1;

            var deleteCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($id:ID!) {
  countryData {
    currency {
      delete(id:$id)
    }
  }
}",
                OperationName = "myMutation",
                Variables = new
                {
                    id
                }
            };

            // Act
            var response = await client.SendMutationAsync(deleteCurrencyRequest);

            // Assert
            response.Errors.Should().BeNull();
            bool deleted = response.Data.countryData.currency.delete;
            deleted.Should().BeFalse();
        }
    }
}
