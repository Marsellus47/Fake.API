using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CountryPartialUpdateInputType : InputObjectGraphType<Country>
    {
        public CountryPartialUpdateInputType()
        {
            Field(country => country.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(country => country.Name, nullable: true);
            Field(country => country.PostCodeRegex, nullable: true);
            Field(country => country.PostCodeFormat, nullable: true);
            Field(country => country.PhonePrefix, nullable: true);
            Field(country => country.TopLevelDomain, nullable: true);
            Field(country => country.Continent, nullable: true);
            Field(country => country.Area, nullable: true, type: typeof(FloatGraphType));
            Field(country => country.Capital, nullable: true);
            Field(country => country.Fips, nullable: true);
            Field(country => country.IsoNumeric, nullable: true, type: typeof(IntGraphType));
            Field(country => country.Iso3, nullable: true);
            Field(country => country.Iso, nullable: true);
            Field(country => country.Population, nullable: true, type: typeof(IntGraphType));
            Field(country => country.CurrencyId, nullable: true);
        }
    }
}
