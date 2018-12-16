using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class PlaceUpdateInputType : InputObjectGraphType<Place>
    {
        public PlaceUpdateInputType()
        {
            Field(state => state.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(state => state.Name);
            Field(state => state.PostCode);
            Field(state => state.LatLong);
            Field(state => state.CommunityId);
        }
    }
}
