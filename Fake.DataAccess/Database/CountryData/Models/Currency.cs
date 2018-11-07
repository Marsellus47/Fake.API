using Fake.DataAccess.Database.Infrastructure.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Currency : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public List<Country> Countries { get; set; }
    }
}
