using Fake.TestCore;
using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;
using ModelCurrency = Fake.DataAccess.Database.CountryData.Models.Currency;

namespace Fake.API.IntegrationTests.GraphQL.Mutation.CountryData.Currency
{
    public class UpdateTests : GraphQLTestsBase
    {
        public UpdateTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldUpdateCurrencyWithCorrectData()
        {
            // Arrange
            var client = GetGraphQLClient();

            const int id = 1;
            const string code = "code";
            const string name = "name";

            var updateCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($id:ID! $code:String! $name:String!) {
  countryData {
    currency {
      update(currency: {
        id:$id
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
                    id,
                    code,
                    name
                }
            };

            // Act
            var response = await client.SendMutationAsync(updateCurrencyRequest);

            // Assert
            response.Errors.Should().BeNull();
            ModelCurrency updatedCurrency = response.Data.countryData.currency.update.ToObject<ModelCurrency>();
            updatedCurrency.Should().NotBeNull();
            updatedCurrency.Id.Should().Be(id);
            updatedCurrency.Code.Should().Be(code);
            updatedCurrency.Name.Should().Be(name);
        }

        [Fact]
        public async Task ShouldNotUpdateCurrencyWithoutId()
        {
            // Arrange
            var client = GetGraphQLClient(false);

            const string code = "code";
            const string name = "name";

            var updateCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($code:String! $name:String!) {
  countryData {
    currency {
      update(currency: {
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
            var response = await client.SendMutationAsync(updateCurrencyRequest);

            // Assert
            AssertMissingMandatoryField(response, nameof(ModelCurrency.Id));
        }

        [Fact]
        public async Task ShouldNotUpdateCurrencyWithoutCode()
        {
            // Arrange
            var client = GetGraphQLClient(false);

            const int id = 1;
            const string name = "name";

            var updateCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($id:ID! $name:String!) {
  countryData {
    currency {
      update(currency: {
        id:$id
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
                    id,
                    name
                }
            };

            // Act
            var response = await client.SendMutationAsync(updateCurrencyRequest);

            // Assert
            AssertMissingMandatoryField(response, nameof(ModelCurrency.Code));
        }

        [Fact]
        public async Task ShouldNotUpdateCurrencyWithoutName()
        {
            // Arrange
            var client = GetGraphQLClient(false);

            const int id = 1;
            const string code = "code";

            var updateCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($id:ID! $code:String!) {
  countryData {
    currency {
      update(currency: {
        id:$id
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
                    id,
                    code
                }
            };

            // Act
            var response = await client.SendMutationAsync(updateCurrencyRequest);

            // Assert
            AssertMissingMandatoryField(response, nameof(ModelCurrency.Name));
        }
    }
}