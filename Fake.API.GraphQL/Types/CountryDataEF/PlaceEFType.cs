using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryDataEF
{
    public class PlaceEFType : EfObjectGraphType<Place>
    {
        public PlaceEFType(IEfGraphQLService efGraphQLService)
            : base(efGraphQLService)
        {
            Field(state => state.Id, type: typeof(IdGraphType));
            Field(state => state.Name);
            Field(state => state.PostCode);
            Field(state => state.LatLong);
            AddNavigationField<CommunityEFType, Community>(
                name: "community",
                resolve: context => context.Source.Community,
                includeNames: new[] { nameof(Place.Community) });
        }
    }
}
