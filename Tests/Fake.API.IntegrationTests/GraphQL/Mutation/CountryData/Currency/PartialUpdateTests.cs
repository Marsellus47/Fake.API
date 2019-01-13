using Fake.TestCore;
using FluentAssertions;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;
using ModelCurrency = Fake.DataAccess.Database.CountryData.Models.Currency;

namespace Fake.API.IntegrationTests.GraphQL.Mutation.CountryData.Currency
{
    public class PartialUpdateTests : GraphQLTestsBase
    {
        public PartialUpdateTests(WebApplicationFactory<Startup> factory)
            : base(factory) { }

        [Fact]
        public async Task ShouldPartiallyUpdateCurrencyWithCorrectData()
        {
            // Arrange
            var client = GetGraphQLClient();

            const int id = 1;
            const string code = "code";
            const string name = "name";

            var partialUpdateCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($id:ID! $code:String $name:String) {
  countryData {
    currency {
      partialUpdate(currency: {
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
            var response = await client.SendMutationAsync(partialUpdateCurrencyRequest);

            // Assert
            response.Errors.Should().BeNull();
            ModelCurrency updatedCurrency = response.Data.countryData.currency.partialUpdate.ToObject<ModelCurrency>();
            updatedCurrency.Should().NotBeNull();
            updatedCurrency.Id.Should().Be(id);
            updatedCurrency.Code.Should().Be(code);
            updatedCurrency.Name.Should().Be(name);
        }

        [Fact]
        public async Task ShouldNotPartiallyUpdateCurrencyWithoutId()
        {
            // Arrange
            var client = GetGraphQLClient(false);

            const string code = "code";
            const string name = "name";

            var partialUpdateCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($code:String $name:String) {
  countryData {
    currency {
      partialUpdate(currency: {
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
            var response = await client.SendMutationAsync(partialUpdateCurrencyRequest);

            // Assert
            AssertMissingMandatoryField(response, nameof(ModelCurrency.Id));
        }

        [Fact]
        public async Task ShouldPartiallyUpdateCurrencyWithoutCode()
        {
            // Arrange
            var client = GetGraphQLClient(true);

            const int id = 1;
            const string name = "name";

            var partialUpdateCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($id:ID! $name:String) {
  countryData {
    currency {
      partialUpdate(currency: {
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
            var response = await client.SendMutationAsync(partialUpdateCurrencyRequest);

            // Assert
            response.Errors.Should().BeNull();
            ModelCurrency updatedCurrency = response.Data.countryData.currency.partialUpdate.ToObject<ModelCurrency>();
            updatedCurrency.Should().NotBeNull();
            updatedCurrency.Id.Should().Be(id);
            updatedCurrency.Code.Should().Be(TestHelper.CurrencyCode);
            updatedCurrency.Name.Should().Be(name);
        }

        [Fact]
        public async Task ShouldNotPartiallyUpdateCurrencyWithNullCode()
        {
            // Arrange
            var client = GetGraphQLClient(true);

            const int id = 1;
            const string name = "name";
            const string code = null;

            var partialUpdateCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($id:ID! $name:String $code:String) {
  countryData {
    currency {
      partialUpdate(currency: {
        id:$id
        name:$name
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
                    name,
                    code
                }
            };

            // Act
            var response = await client.SendMutationAsync(partialUpdateCurrencyRequest);

            // Assert
            AssertNullSemiMandatoryField(response, nameof(ModelCurrency.Code));
        }

        [Fact]
        public async Task ShouldPartiallyUpdateCurrencyWithoutName()
        {
            // Arrange
            var client = GetGraphQLClient(true);

            const int id = 1;
            const string code = "code";

            var partialUpdateCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($id:ID! $code:String) {
  countryData {
    currency {
      partialUpdate(currency: {
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
            var response = await client.SendMutationAsync(partialUpdateCurrencyRequest);

            // Assert
            response.Errors.Should().BeNull();
            ModelCurrency updatedCurrency = response.Data.countryData.currency.partialUpdate.ToObject<ModelCurrency>();
            updatedCurrency.Should().NotBeNull();
            updatedCurrency.Id.Should().Be(id);
            updatedCurrency.Code.Should().Be(code);
            updatedCurrency.Name.Should().Be(TestHelper.CurrencyName);
        }

        [Fact]
        public async Task ShouldNotPartiallyUpdateCurrencyWithNullName()
        {
            // Arrange
            var client = GetGraphQLClient(true);

            const int id = 1;
            const string name = null;
            const string code = "code";

            var partialUpdateCurrencyRequest = new GraphQLRequest
            {
                Query = @"
mutation myMutation($id:ID! $name:String $code:String) {
  countryData {
    currency {
      partialUpdate(currency: {
        id:$id
        name:$name
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
                    name,
                    code
                }
            };

            // Act
            var response = await client.SendMutationAsync(partialUpdateCurrencyRequest);

            // Assert
            AssertNullSemiMandatoryField(response, nameof(ModelCurrency.Name));
        }
    }
}