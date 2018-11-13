using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;
using Humanizer;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class LanguageInsertInputType : InputObjectGraphType
    {
        public LanguageInsertInputType()
        {
            Name = "LanguageInsertInputType";

            Field<NonNullGraphType<StringGraphType>>(nameof(Language.Code).Camelize());
        }
    }
}
