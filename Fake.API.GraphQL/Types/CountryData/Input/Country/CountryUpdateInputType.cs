using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;
using Humanizer;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CountryUpdateInputType : InputObjectGraphType
    {
        public CountryUpdateInputType()
        {
            Name = "CountryUpdateInputType";

            Field<NonNullGraphType<IdGraphType>>(nameof(Country.Id).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Country.Name).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Country.PostCodeRegex).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Country.PostCodeFormat).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Country.PhonePrefix).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Country.TopLevelDomain).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Country.Continent).Camelize());
            Field<NonNullGraphType<FloatGraphType>>(nameof(Country.Area).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Country.Capital).Camelize());
            Field<StringGraphType>(nameof(Country.Fips).Camelize());
            Field<NonNullGraphType<IntGraphType>>(nameof(Country.IsoNumeric).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Country.Iso3).Camelize());
            Field<NonNullGraphType<StringGraphType>>(nameof(Country.Iso).Camelize());
            Field<IntGraphType>(nameof(Country.Population).Camelize());
            Field<NonNullGraphType<IntGraphType>>(nameof(Country.CurrencyId).Camelize());
        }
    }
}
