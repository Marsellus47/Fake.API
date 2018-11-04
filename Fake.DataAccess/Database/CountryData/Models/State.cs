using Fake.DataAccess.Database.Infrastructure.Model;
using System.Collections.Generic;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class State : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Province> Provinces { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
