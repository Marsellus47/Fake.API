using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class PlaceType : ObjectGraphType<Place>
    {
        public PlaceType(IDataLoaderContextAccessor accessor, ICommunityRepository communityRepository)
        {
            Field(state => state.Id, type: typeof(IdGraphType));
            Field(state => state.Name);
            Field(state => state.PostCode);
            Field(state => state.LatLong);
            Field<CommunityType, Community>()
                .Name("community")
                .ResolveAsync(context =>
                {
                    var communityDataLoader = accessor.Context.GetOrAddBatchLoader<int, Community>(nameof(communityRepository.GetCommunitiesAsync), communityRepository.GetCommunitiesAsync);
                    return communityDataLoader.LoadAsync(context.Source.CommunityId);
                });
        }
    }
}
