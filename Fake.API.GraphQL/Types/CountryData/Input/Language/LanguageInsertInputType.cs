using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class LanguageInsertInputType : InputObjectGraphType<Language>
    {
        public LanguageInsertInputType()
        {
            Field(language => language.Code);
        }
    }
}
