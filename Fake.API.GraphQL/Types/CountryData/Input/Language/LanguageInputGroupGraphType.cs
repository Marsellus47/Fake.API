using Fake.API.GraphQL.Types.CountryData.Output;
using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;
using Humanizer;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class LanguageInputGroupGraphType : ObjectGraphType
    {
        public LanguageInputGroupGraphType(ILanguageRepository languageRepository)
        {
            FieldAsync<NonNullGraphType<LanguageType>>(
                "insert",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LanguageInsertInputType>> { Name = "language" }),
                resolve: async (context) =>
                {
                    var language = context.GetArgument<Language>("language");
                    await languageRepository.InsertAsync(language);
                    return language;
                });

            FieldAsync<LanguageType>(
                "update",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LanguageUpdateInputType>> { Name = "language" }),
                resolve: async (context) =>
                {
                    var language = context.GetArgument<Language>("language");
                    await languageRepository.UpdateAsync(language);
                    return language;
                });

            FieldAsync<NonNullGraphType<BooleanGraphType>>(
                "delete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = nameof(Language.Id).Camelize() }),
                resolve: async (context) =>
                {
                    var id = context.GetArgument<int>(nameof(Language.Id).Camelize());
                    return await languageRepository.DeleteAsync(id);
                });
        }
    }
}
