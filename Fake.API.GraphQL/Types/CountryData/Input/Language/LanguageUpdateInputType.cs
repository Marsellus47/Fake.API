using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class LanguageUpdateInputType : InputObjectGraphType<Language>
    {
        public LanguageUpdateInputType()
        {
            Field(currency => currency.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(currency => currency.Code);
        }
    }
}
