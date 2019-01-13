using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CurrencyUpdateInputType : InputObjectGraphType<Currency>
    {
        public CurrencyUpdateInputType()
        {
            Field(currency => currency.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(currency => currency.Code);
            Field(currency => currency.Name);
        }
    }
}
