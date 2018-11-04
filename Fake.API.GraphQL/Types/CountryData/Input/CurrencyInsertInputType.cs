using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;
using Humanizer;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CurrencyInsertInputType : InputObjectGraphType
    {
        public CurrencyInsertInputType()
        {
            Name = "CurrencyInsertInput";

            Field<NonNullGraphType<StringGraphType>>(nameof(Currency.Code).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Currency.Name).Camelize());
        }
    }
}
