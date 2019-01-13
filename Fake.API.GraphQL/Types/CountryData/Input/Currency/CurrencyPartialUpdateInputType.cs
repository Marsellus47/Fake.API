using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CurrencyPartialUpdateInputType : InputObjectGraphType<Currency>
    {
        public CurrencyPartialUpdateInputType()
        {
            Field(currency => currency.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(currency => currency.Code, nullable: true);
            Field(currency => currency.Name, nullable: true);
        }
    }
}
