using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CountryInsertInputType : InputObjectGraphType<Country>
    {
        public CountryInsertInputType()
        {
            Field(country => country.Name);
            Field(country => country.PostCodeRegex);
            Field(country => country.PostCodeFormat);
            Field(country => country.PhonePrefix);
            Field(country => country.TopLevelDomain);
            Field(country => country.Continent);
            Field(country => country.Area, type: typeof(FloatGraphType));
            Field(country => country.Capital);
            Field(country => country.Fips, nullable: true);
            Field(country => country.IsoNumeric, type: typeof(IntGraphType));
            Field(country => country.Iso3);
            Field(country => country.Iso);
            Field(country => country.Population, nullable: true, type: typeof(IntGraphType));
            Field(country => country.CurrencyId);
            Field<ListGraphType<StringGraphType>>("languages");
        }
    }
}
