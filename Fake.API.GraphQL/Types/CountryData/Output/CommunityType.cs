using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData.Output
{
    public class CommunityType : ObjectGraphType<Community>
    {
        public CommunityType(
            IDataLoaderContextAccessor accessor,
            IProvinceRepository provinceRepository,
            IPlaceRepository placeRepository)
        {
            Field(state => state.Id, type: typeof(IdGraphType));
            Field(state => state.Name, nullable: true);
            Field(state => state.Code, nullable: true);
            Field<ProvinceType, Province>()
                .Name("province")
                .ResolveAsync(context =>
                {
                    var provinceDataLoader = accessor.Context.GetOrAddBatchLoader<int, Province>(nameof(provinceRepository.GetProvincesAsync), provinceRepository.GetProvincesAsync);
                    return provinceDataLoader.LoadAsync(context.Source.ProvinceId);
                });
            Field<ListGraphType<PlaceType>, IEnumerable<Place>>()
                .Name("places")
                .ResolveAsync(context =>
                {
                    var placeDataLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Place>(nameof(placeRepository.GetPlacesByCommunityIdsAsync), placeRepository.GetPlacesByCommunityIdsAsync);
                    return placeDataLoader.LoadAsync(context.Source.Id);
                });
        }
    }
}
