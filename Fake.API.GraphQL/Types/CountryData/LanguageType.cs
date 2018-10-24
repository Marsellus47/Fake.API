using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class LanguageType : ObjectGraphType<Language>
    {
        public LanguageType()
        {
            Field(c => c.Id);
            Field(c => c.Code);
        }
    }
}
