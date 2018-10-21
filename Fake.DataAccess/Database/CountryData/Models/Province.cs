using System.Collections.Generic;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        //public List<Community> Communities { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }
    }
}
