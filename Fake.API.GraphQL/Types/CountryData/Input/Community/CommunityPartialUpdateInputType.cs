using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CommunityPartialUpdateInputType : InputObjectGraphType<Community>
    {
        public CommunityPartialUpdateInputType()
        {
            Field(community => community.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(community => community.Name, nullable: true);
            Field(community => community.Code, nullable: true);
            Field(community => community.ProvinceId, nullable: true);
        }
    }
}
