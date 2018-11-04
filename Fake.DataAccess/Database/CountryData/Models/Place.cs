using Fake.DataAccess.Database.Infrastructure.Model;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Place : Entity
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string LatLong { get; set; }

        public int CommunityId { get; set; }
        public Community Community { get; set; }
    }
}
