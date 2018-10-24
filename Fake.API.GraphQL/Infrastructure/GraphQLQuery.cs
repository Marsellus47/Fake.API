using Fake.API.GraphQL.Types;
using Fake.API.GraphQL.Types.CountryData;
using Fake.DataAccess.Database.CountryData;
using GraphQL.Types;
using System.Linq;

namespace Fake.API.GraphQL.Infrastructure
{
    public class GraphQLQuery : ObjectGraphType
    {
        public GraphQLQuery(CountryDataContext countryDataContext)
        {
            Field<RandomGroupGraphType>("random", resolve: ctx => new { });

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
        }

        #endregion
    }
}
