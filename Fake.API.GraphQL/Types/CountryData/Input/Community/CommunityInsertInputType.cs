using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CommunityInsertInputType : InputObjectGraphType<Community>
    {
        public CommunityInsertInputType()
        {
            Field(community => community.Name);
            Field(community => community.Code);
            Field(community => community.ProvinceId);
        }
    }
}
