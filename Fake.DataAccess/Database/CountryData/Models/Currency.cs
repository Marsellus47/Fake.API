using Fake.DataAccess.Database.Infrastructure.Model;
using System.Collections.Generic;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Currency : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public List<Country> Countries { get; set; }
    }
}
