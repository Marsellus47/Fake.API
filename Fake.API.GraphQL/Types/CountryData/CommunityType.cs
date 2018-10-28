using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class CommunityType : ObjectGraphType<Community>
    {
        public CommunityType(IProvinceRepository provinceRepository, IPlaceRepository placeRepository)
        {
            Field(state => state.Id);
            Field(state => state.Name, nullable: true);
            Field(state => state.Code, nullable: true);
            Field<ProvinceType, Province>()
                .Name("province")
                .ResolveAsync(context => provinceRepository.GetProvinceByIdAsync(context.Source.ProvinceId));
            Field<ListGraphType<PlaceType>, IEnumerable<Place>>()
                .Name("places")
                .ResolveAsync(ctx => placeRepository.GetPlacesByCommunityIdAsync(ctx.Source.Id));
        }
    }
}
