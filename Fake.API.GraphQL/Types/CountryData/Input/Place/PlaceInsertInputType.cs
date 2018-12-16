using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class PlaceInsertInputType : InputObjectGraphType<Place>
    {
        public PlaceInsertInputType()
        {
            Field(state => state.Name);
            Field(state => state.PostCode);
            Field(state => state.LatLong);
            Field(state => state.CommunityId);
        }
    }
}
