using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CurrencyInsertInputType : InputObjectGraphType<Currency>
    {
        public CurrencyInsertInputType()
        {
            Field(currency => currency.Code);
            Field(currency => currency.Name);
        }
    }
}
