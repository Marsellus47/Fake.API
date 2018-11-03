using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryDataEF
{
    public class CommunityEFType : EfObjectGraphType<Community>
    {
        public CommunityEFType(IEfGraphQLService efGraphQLService)
            : base(efGraphQLService)
        {
            Field(state => state.Id, type: typeof(IdGraphType));
            Field(state => state.Name, nullable: true);
            Field(state => state.Code, nullable: true);
            AddNavigationField<ProvinceEFType, Province>(
                name: "province",
                resolve: context => context.Source.Province,
                includeNames: new[] { nameof(Community.Province) });
            AddNavigationField<PlaceEFType, Place>(
                name: "places",
                resolve: context => context.Source.Places,
                includeNames: new[] { nameof(Community.Places) });
        }
    }
}
