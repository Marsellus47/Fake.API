using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData.Output
{
    public class ProvinceType : ObjectGraphType<Province>
    {
        public ProvinceType(
            IDataLoaderContextAccessor accessor,
            IStateRepository stateRepository,
            ICommunityRepository communityRepository)
        {
            Field(state => state.Id, type: typeof(IdGraphType));
            Field(state => state.Name, nullable: true);
            Field(state => state.Code, nullable: true);
            Field<StateType, State>()
                .Name("state")
                .ResolveAsync(context =>
                {
                    var stateDataLoader = accessor.Context.GetOrAddBatchLoader<int, State>(nameof(stateRepository.GetStatesAsync), stateRepository.GetStatesAsync);
                    return stateDataLoader.LoadAsync(context.Source.StateId);
                });
            Field<ListGraphType<CommunityType>, IEnumerable<Community>>()
                .Name("communities")
                .ResolveAsync(context =>
                {
                    var communityDataLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Community>(nameof(communityRepository.GetCommunitiesByProvinceIdsAsync), communityRepository.GetCommunitiesByProvinceIdsAsync);
                    return communityDataLoader.LoadAsync(context.Source.Id);
                });
        }
    }
}
