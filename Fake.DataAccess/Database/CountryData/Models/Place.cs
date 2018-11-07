using Fake.DataAccess.Database.Infrastructure.Model;
using System.ComponentModel.DataAnnotations;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Place : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string LatLong { get; set; }

        public int CommunityId { get; set; }
        public Community Community { get; set; }
    }
}
