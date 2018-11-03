using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData;
using GraphQL.EntityFramework;
using GraphQL.Types;
using System.Linq;

namespace Fake.API.GraphQL.Types.CountryDataEF
{
    public class LanguageEFType : EfObjectGraphType<Language>
    {
        public LanguageEFType(IEfGraphQLService efGraphQLService, CountryDataContext countryDataContext)
            : base(efGraphQLService)
        {
            Field(c => c.Id, type: typeof(IdGraphType));
            Field(c => c.Code);
            AddNavigationField<CountryEFType, Country>(
                name: "countries",
                resolve: context => countryDataContext.CountryLanguage.Where(x => x.LanguageId == context.Source.Id).Select(x => x.Country),
                includeNames: new[] { nameof(CountryLanguage.Country) });
        }
    }
}
