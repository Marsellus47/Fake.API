using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class CommunityType : ObjectGraphType<Community>
    {
        public CommunityType(IProvinceRepository provinceRepository)
        {
            Field(state => state.Id);
            Field(state => state.Name);
            Field(state => state.Code);
            Field<ProvinceType, Province>()
                .Name("province")
                .ResolveAsync(context => provinceRepository.GetProvinceByIdAsync(context.Source.ProvinceId));
        }
    }
}
