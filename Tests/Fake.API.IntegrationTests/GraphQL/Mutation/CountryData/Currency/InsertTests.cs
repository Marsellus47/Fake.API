using Fake.API.IntegrationTests.Infrastructure;
using Fake.API.IntegrationTests.Infrastructure.IdentityServer;
using FluentAssertions;
using GraphQL.Common.Request;
using System.Threading.Tasks;
using Xunit;
using ModelCurrency = Fake.DataAccess.Database.CountryData.Models.Currency;

namespace Fake.API.IntegrationTests.GraphQL.Mutation.CountryData.Currency
{
    [Collection(WebHostHelper.IntegrationTestsWithIdentityServerCollectionName)]
    public class InsertTests : GraphQLTestsBase
    {
        public InsertTests(IdentityServerAuthenticationHostFixture hostFixture)
            : base(hostFixture) { }

        [Fact]
        public async Task ShouldInsertCurrencyWithCorrectData()
        {
            // Arrange
            var client = GetGraphQLClient(false)
                .WithAuthorization(IdentityServerSetup.Instance.GetAccessTokenForUser("user", "password").Result);

            const string code = "code";
            const string name = "name";

            var insertCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($code:String! $name:String!) {
  countryData {
    currency {
      insert(currency: {
        code:$code
        name:$name
      }) {
        id
        name
        code
      }
    }
  }
}",
                OperationName = "myMutation",
                Variables = new
                {
                    code,
                    name
                }
            };

            // Act
            var response = await client.SendMutationAsync(insertCurrencyRequest);

            // Assert
            response.Errors.Should().BeNull();
            ModelCurrency createdCurrency = response.Data.countryData.currency.insert.ToObject<ModelCurrency>();
            createdCurrency.Should().NotBeNull();
            createdCurrency.Id.Should().NotBe(default(int));
            createdCurrency.Code.Should().Be(code);
            createdCurrency.Name.Should().Be(name);
        }

        [Fact]
        public async Task ShouldNotInsertCurrencyWithoutCode()
        {
            // Arrange
            var client = GetGraphQLClient(false)
                .WithAuthorization(IdentityServerSetup.Instance.GetAccessTokenForUser("user", "password").Result);

            const string name = "name";

            var insertCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($name:String!) {
  countryData {
    currency {
      insert(currency: {
        name:$name
      }) {
        id
        name
        code
      }
    }
  }
}",
                OperationName = "myMutation",
                Variables = new
                {
                    name
                }
            };

            // Act
            var response = await client.SendMutationAsync(insertCurrencyRequest);

            // Assert
            AssertMissingMandatoryField(response, nameof(ModelCurrency.Code));
        }

        [Fact]
        public async Task ShouldNotInsertCurrencyWithoutName()
        {
            // Arrange
            var client = GetGraphQLClient(false);

            const string code = "code";

            var insertCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($code:String!) {
  countryData {
    currency {
      insert(currency: {
        code:$code
      }) {
        id
        name
        code
      }
    }
  }
}",
                OperationName = "myMutation",
                Variables = new
                {
                    code
                }
            };

            // Act
            var response = await client.SendMutationAsync(insertCurrencyRequest);

            // Assert
            AssertMissingMandatoryField(response, nameof(ModelCurrency.Name));
        }
    }
}
