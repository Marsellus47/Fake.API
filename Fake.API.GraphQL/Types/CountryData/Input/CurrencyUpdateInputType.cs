using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;
using Humanizer;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CurrencyUpdateInputType : InputObjectGraphType
    {
        public CurrencyUpdateInputType()
        {
            Name = "CurrencyUpdateInput";

            Field<NonNullGraphType<IdGraphType>>(nameof(Currency.Id).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Currency.Code).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Currency.Name).Camelize());
        }
    }
}
