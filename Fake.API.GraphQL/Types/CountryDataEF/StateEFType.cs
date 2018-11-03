using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryDataEF
{
    public class StateEFType : EfObjectGraphType<State>
    {
        public StateEFType(IEfGraphQLService efGraphQLService)
            : base(efGraphQLService)
        {
            Field(state => state.Id, type: typeof(IdGraphType));
            Field(state => state.Name);
            Field(state => state.Code, nullable: true);
            AddNavigationField<CountryEFType, Country>(
                name: "country",
                resolve: context => context.Source.Country,
                includeNames: new[] { nameof(State.Country) });
            AddNavigationField<ProvinceEFType, Province>(
                name: "provinces",
                resolve: context => context.Source.Provinces,
                includeNames: new[] { nameof(State.Provinces) });
            AddNavigationConnectionField<ProvinceEFType, Province>(
                name: "provincesConnection",
                resolve: context => context.Source.Provinces,
                includeNames: new[] { nameof(State.Provinces) });
        }
    }
}
