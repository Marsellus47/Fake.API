using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;
using Humanizer;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CountryPartialUpdateInputType : InputObjectGraphType
    {
        public CountryPartialUpdateInputType()
        {
            Name = "CountryPartialUpdateInputType";

            Field<NonNullGraphType<IdGraphType>>(nameof(Country.Id).Camelize());
            Field<StringGraphType>(nameof(Country.Name).Camelize());
            Field<StringGraphType>(nameof(Country.PostCodeRegex).Camelize());
            Field<StringGraphType>(nameof(Country.PostCodeFormat).Camelize());
            Field<StringGraphType>(nameof(Country.PhonePrefix).Camelize());
            Field<StringGraphType>(nameof(Country.TopLevelDomain).Camelize());
            Field<StringGraphType>(nameof(Country.Continent).Camelize());
            Field<FloatGraphType>(nameof(Country.Area).Camelize());
            Field<StringGraphType>(nameof(Country.Capital).Camelize());
            Field<StringGraphType>(nameof(Country.Fips).Camelize());
            Field<IntGraphType>(nameof(Country.IsoNumeric).Camelize());
            Field<StringGraphType>(nameof(Country.Iso3).Camelize());
            Field<StringGraphType>(nameof(Country.Iso).Camelize());
            Field<IntGraphType>(nameof(Country.Population).Camelize());
            Field<IntGraphType>(nameof(Country.CurrencyId).Camelize());
        }
    }
}
