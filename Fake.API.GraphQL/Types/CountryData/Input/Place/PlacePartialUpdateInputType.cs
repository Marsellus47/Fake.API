using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class PlacePartialUpdateInputType : InputObjectGraphType<Place>
    {
        public PlacePartialUpdateInputType()
        {
            Field(state => state.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(state => state.Name, nullable: true);
            Field(state => state.PostCode, nullable: true);
            Field(state => state.LatLong, nullable: true);
            Field(state => state.CommunityId, nullable: true);
        }
    }
}
