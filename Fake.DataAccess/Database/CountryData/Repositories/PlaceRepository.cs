using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class PlaceRepository : ReadWriteRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(CountryDataContext countryDataContext)
            : base(countryDataContext) { }

        public Task<IEnumerable<Place>> GetPlacesAsync()
        {
            return GetAllAsync();
        }

        public Task<IEnumerable<Place>> GetPlacesByCommunityIdAsync(int communityId)
        {
            return GetFilteredAsync(place => place.CommunityId == communityId);
        }

        public async Task<ILookup<int, Place>> GetPlacesByCommunityIdsAsync(IEnumerable<int> communityIds)
        {
            var places = await GetFilteredAsync(place => communityIds.Contains(place.CommunityId));
            return places.ToLookup(place => place.CommunityId);
        }

        public Task<Place> GetPlaceByIdAsync(int id)
        {
            return FindAsync(id);
        }

        public Task<Place> GetPlaceByNameAsync(string name)
        {
            return GetFirstAsync(place => place.Name == name);
        }
    }
}
