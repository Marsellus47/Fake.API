using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryDataEF
{
    public class ProvinceEFType : EfObjectGraphType<Province>
    {
        public ProvinceEFType(IEfGraphQLService efGraphQLService)
            : base(efGraphQLService)
        {
            Field(state => state.Id, type: typeof(IdGraphType));
            Field(state => state.Name, nullable: true);
            Field(state => state.Code, nullable: true);
            AddNavigationField<StateEFType, State>(
                name: "state",
                resolve: context => context.Source.State,
                includeNames: new[] { nameof(Province.State) });
            AddNavigationField<CommunityEFType, Community>(
                name: "communities",
                resolve: context => context.Source.Communities,
                includeNames: new[] { nameof(Province.Communities) });
        }
    }
}
