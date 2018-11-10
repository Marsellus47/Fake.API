using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;
using Humanizer;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class LanguageUpdateInputType : InputObjectGraphType
    {
        public LanguageUpdateInputType()
        {
            Name = "LanguageUpdateInputType";

            Field<NonNullGraphType<IdGraphType>>(nameof(Language.Id).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Language.Code).Camelize());
        }
    }
}
