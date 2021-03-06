﻿using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake.DataAccess.Database.CountryData.Repositories
{
    public interface IPlaceRepository : IReadWriteRepository<Place>
    {
        Task<IEnumerable<Place>> GetPlacesAsync();
        Task<IEnumerable<Place>> GetPlacesByCommunityIdAsync(int communityId);
        Task<ILookup<int, Place>> GetPlacesByCommunityIdsAsync(IEnumerable<int> communityIds);
        Task<Place> GetPlaceByIdAsync(int id);
        Task<Place> GetPlaceByNameAsync(string name);
    }
}
