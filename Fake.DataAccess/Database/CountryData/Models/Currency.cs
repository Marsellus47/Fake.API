using System.Collections.Generic;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public List<Country> Countries { get; set; }
    }
}
