using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CountryDataInputGroupGraphType : ObjectGraphType
    {
        public CountryDataInputGroupGraphType()
        {
            Field<CurrencyInputGroupGraphType>("currency", resolve: context => new { });
            Field<LanguageInputGroupGraphType>("language", resolve: context => new { });
            Field<CountryInputGroupGraphType>("country", resolve: context => new { });
            Field<StateInputGroupGraphType>("state", resolve: context => new { });
            Field<ProvinceInputGroupGraphType>("province", resolve: context => new { });
        }
    }
}
