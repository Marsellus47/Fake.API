using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CommunityUpdateInputType : InputObjectGraphType<Community>
    {
        public CommunityUpdateInputType()
        {
            Field(community => community.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(community => community.Name);
            Field(community => community.Code);
            Field(community => community.ProvinceId);
        }
    }
}
