using Fake.API.GraphQL.Types.CountryData.Input;
using Fake.API.GraphQL.Types.CountryData.Output;
using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;
using Humanizer;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Infrastructure
{
    public class GraphQLMutation : ObjectGraphType
    {
        public GraphQLMutation(ICurrencyRepository currencyRepository)
        {
            #region Currency

            FieldAsync<NonNullGraphType<CurrencyType>>(
                "insertCurrency",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CurrencyInsertInputType>> { Name = "currency" }),
                resolve: async (context) =>
                {
                    var currency = context.GetArgument<Currency>("currency");
                    await currencyRepository.InsertAsync(currency);
                    return currency;
                });

            FieldAsync<CurrencyType>(
                "updateCurrency",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CurrencyUpdateInputType>> { Name = "currency" }),
                resolve: async(context) =>
                {
                    var currency = context.GetArgument<Currency>("currency");
                    return await currencyRepository.UpdateAsync(currency);
                });

            FieldAsync<CurrencyType>(
                "partialUpdateCurrency",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CurrencyPartialUpdateInputType>> { Name = "currency" }),
                resolve: async (context) =>
                {
                    var values = context.Arguments["currency"] as IDictionary<string, object>;
                    return await currencyRepository.PartiallyUpdateAsync(values);
                });

            FieldAsync<NonNullGraphType<BooleanGraphType>>(
                "deleteCurrency",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = nameof(Currency.Id).Camelize() }),
                resolve: async (context) =>
                {
                    var id = context.GetArgument<int>(nameof(Currency.Id).Camelize());
                    return await currencyRepository.DeleteAsync(id);
                });

            #endregion
        }
    }
}
