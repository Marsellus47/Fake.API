using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly CountryDataContext _countryDataContext;

        public PlaceRepository(CountryDataContext countryDataContext)
        {
            _countryDataContext = countryDataContext;
        }

        public async Task<IEnumerable<Place>> GetPlacesAsync()
        {
            return await _countryDataContext.Place.ToListAsync();
        }

        public async Task<IEnumerable<Place>> GetPlacesByCommunityIdAsync(int communityId)
        {
            return await _countryDataContext.Place.Where(place => place.CommunityId == communityId).ToListAsync();
        }

        public Task<Place> GetPlaceByIdAsync(int id)
        {
            return _countryDataContext.Place.FindAsync(id);
        }

        public Task<Place> GetPlaceByNameAsync(string name)
        {
            return _countryDataContext.Place.FirstOrDefaultAsync(place => place.Name == name);
        }
    }
}
