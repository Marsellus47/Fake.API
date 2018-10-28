using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class PlaceType : ObjectGraphType<Place>
    {
        public PlaceType(ICommunityRepository communityRepository)
        {
            Field(state => state.Id);
            Field(state => state.Name);
            Field(state => state.PostCode);
            Field(state => state.LatLong);
            Field<CommunityType, Community>()
                .Name("community")
                .ResolveAsync(context => communityRepository.GetCommunityByIdAsync(context.Source.CommunityId));
        }
    }
}
