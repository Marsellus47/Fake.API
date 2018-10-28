using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class ProvinceType : ObjectGraphType<Province>
    {
        public ProvinceType(IStateRepository stateRepository, ICommunityRepository communityRepository)
        {
            Field(state => state.Id);
            Field(state => state.Name);
            Field(state => state.Code);
            Field<StateType, State>()
                .Name("state")
                .ResolveAsync(context => stateRepository.GetStateByIdAsync(context.Source.StateId));
            Field<ListGraphType<CommunityType>, IEnumerable<Community>>()
                .Name("communities")
                .ResolveAsync(ctx => communityRepository.GetCommunitiesByProvinceIdAsync(ctx.Source.Id));
        }
    }
}
