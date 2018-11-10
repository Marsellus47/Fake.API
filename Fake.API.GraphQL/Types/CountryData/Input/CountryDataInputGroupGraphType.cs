using Fake.API.GraphQL.Types.CountryData.Output;
using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL;
using GraphQL.Types;
using Humanizer;
using System.Collections.Generic;
using System.Linq;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CountryDataInputGroupGraphType : ObjectGraphType
    {
        public CountryDataInputGroupGraphType(ICurrencyRepository currencyRepository)
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
                resolve: async (context) =>
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

                    ValidateMandatoryField(context, values, nameof(Currency.Code));
                    ValidateMandatoryField(context, values, nameof(Currency.Name));

                    if (context.Errors.Any())
                        return null;

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

        private void ValidateMandatoryField(ResolveFieldContext<object> context, IDictionary<string, object> values, string fieldName)
        {
            if (values.TryGetValue(fieldName.Camelize(), out object fieldValue) && fieldValue == null)
            {
                context.Errors.Add(new ExecutionError($"{fieldName.Camelize()} is mandatory"));
            }
        }
    }
}
