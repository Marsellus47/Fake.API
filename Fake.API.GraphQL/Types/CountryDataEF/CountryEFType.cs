using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData;
using GraphQL.EntityFramework;
using GraphQL.Types;
using System.Linq;

namespace Fake.API.GraphQL.Types.CountryDataEF
{
    public class CountryEFType : EfObjectGraphType<Country>
    {
        public CountryEFType(IEfGraphQLService efGraphQLService, CountryDataContext countryDataContext)
            : base(efGraphQLService)
        {
            Field(c => c.Id, type: typeof(IdGraphType));
            Field(c => c.Name);
            Field(c => c.PostCodeRegex);
            Field(c => c.PostCodeFormat);
            Field(c => c.PhonePrefix);
            Field(c => c.TopLevelDomain);
            Field(c => c.Continent);
            Field(c => c.Area);
            Field(c => c.Capital);
            Field(c => c.Fips);
            Field(c => c.IsoNumeric, type: typeof(IntGraphType));
            Field(c => c.Iso3);
            Field(c => c.Iso);
            Field(c => c.Population, type: typeof(IntGraphType));
            AddNavigationField<CurrencyEFType, Currency>(
                name: "currency",
                resolve: context => context.Source.Currency,
                includeNames: new[] { nameof(Country.Currency) });
            AddNavigationField<StateEFType, State>(
                name: "states",
                resolve: context => context.Source.States,
                includeNames: new[] { nameof(Country.States) });
            AddNavigationField<LanguageEFType, Language>(
                name: "languages",
                resolve: context => countryDataContext.CountryLanguage.Where(x => x.CountryId == context.Source.Id).Select(x => x.Language),
                includeNames: new[] { nameof(Country.CountryLanguages), $"{nameof(Country.CountryLanguages)}.{nameof(CountryLanguage.Language)}" });
        }
    }
}
