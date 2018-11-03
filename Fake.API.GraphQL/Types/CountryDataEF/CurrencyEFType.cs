using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryDataEF
{
    public class CurrencyEFType : EfObjectGraphType<Currency>
    {
        public CurrencyEFType(IEfGraphQLService efGraphQLService)
            : base(efGraphQLService)
        {
            Field(c => c.Id, type: typeof(IdGraphType));
            Field(c => c.Name);
            Field(c => c.Code);
            AddNavigationField<CountryEFType, Country>(
                name: "countries",
                resolve: context => context.Source.Countries,
                includeNames: new[] { nameof(Currency.Countries) });
        }
    }
}
