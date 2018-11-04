using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;
using Humanizer;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CurrencyPartialUpdateInputType : InputObjectGraphType
    {
        public CurrencyPartialUpdateInputType()
        {
            Name = "CurrencyPartialUpdateInput";

            Field<NonNullGraphType<IdGraphType>>(nameof(Currency.Id).Camelize());
            Field<StringGraphType>(nameof(Currency.Code).Camelize());
            Field<StringGraphType>(nameof(Currency.Name).Camelize());
        }
    }
}
