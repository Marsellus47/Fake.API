using Fake.API.GraphQL.Helpers;
using Fake.API.GraphQL.Types.CountryData.Output;
using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;
using Humanizer;
using System.Collections.Generic;
using System.Linq;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CurrencyInputGroupGraphType : ObjectGraphType
    {
        public CurrencyInputGroupGraphType(ICurrencyRepository currencyRepository)
        {
            FieldAsync<NonNullGraphType<CurrencyType>>(
                "insert",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CurrencyInsertInputType>> { Name = "currency" }),
                resolve: async (context) =>
                {
                    var currency = context.GetArgument<Currency>("currency");
                    await currencyRepository.InsertAsync(currency);
                    return currency;
                });

            FieldAsync<CurrencyType>(
                "update",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CurrencyUpdateInputType>> { Name = "currency" }),
                resolve: async (context) =>
                {
                    var currency = context.GetArgument<Currency>("currency");
                    return await currencyRepository.UpdateAsync(currency);
                });

            FieldAsync<CurrencyType>(
                "partialUpdate",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CurrencyPartialUpdateInputType>> { Name = "currency" }),
                resolve: async (context) =>
                {
                    var values = context.Arguments["currency"] as IDictionary<string, object>;

                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Currency.Code));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Currency.Name));

                    if (context.Errors.Any())
                        return null;

                    return await currencyRepository.PartiallyUpdateAsync(values);
                });

            FieldAsync<NonNullGraphType<BooleanGraphType>>(
                "delete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = nameof(Currency.Id).Camelize() }),
                resolve: async (context) =>
                {
                    var id = context.GetArgument<int>(nameof(Currency.Id).Camelize());
                    return await currencyRepository.DeleteAsync(id);
                });
        }
    }
}
