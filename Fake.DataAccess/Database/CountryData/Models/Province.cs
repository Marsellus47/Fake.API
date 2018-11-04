using Fake.DataAccess.Database.Infrastructure.Model;
using System.Collections.Generic;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Province : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Community> Communities { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }
    }
}
