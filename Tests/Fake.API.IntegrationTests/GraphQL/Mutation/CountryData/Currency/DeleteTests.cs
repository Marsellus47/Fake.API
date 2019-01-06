using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;
using ModelCurrency = Fake.DataAccess.Database.CountryData.Models.Currency;

namespace Fake.API.IntegrationTests.GraphQL.Mutation.CountryData.Currency
{
    public class DeleteTests : GraphQLTestsBase
    {
        public DeleteTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldDeleteExistingCurrency()
        {
            // Arrange
            var client = GetGraphQLClient(true);

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
            var client = GetGraphQLClient(false);

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
