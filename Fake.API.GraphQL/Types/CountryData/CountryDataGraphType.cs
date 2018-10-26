using Fake.DataAccess.Database.CountryData;
using GraphQL.Types;
using System.Linq;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class CountryDataGraphType : ObjectGraphType
    {
        public CountryDataGraphType(CountryDataContext countryDataContext)
        {

            #region Currency

            Field<CurrencyType>(
                name: "currency",
                description: "Currency",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code", Description = "Currency code" }),
                resolve: context =>
                {
                    var code = context.GetArgument<string>("code");
                    return countryDataContext.Currency.SingleOrDefault(currency => currency.Code == code);
                });

            Field<ListGraphType<CurrencyType>>(
                "currencies",
                resolve: context => countryDataContext.Currency.ToList());

            #endregion

            #region Language

            Field<LanguageType>(
                name: "language",
                description: "Language",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code", Description = "Language code" }),
                resolve: context =>
                {
                    var code = context.GetArgument<string>("code");
                    return countryDataContext.Language.SingleOrDefault(currency => currency.Code == code);
                });

            Field<ListGraphType<LanguageType>>(
                "languages",
                resolve: context => countryDataContext.Language.ToList());

            #endregion
        }
    }
}
