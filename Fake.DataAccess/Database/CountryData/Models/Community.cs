using Fake.DataAccess.Database.Infrastructure.Model;
using System.Collections.Generic;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Community : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Place> Places { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
