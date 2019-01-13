using Fake.DataAccess.Database.Infrastructure.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Language : Entity
    {
        [Required]
        public string Code { get; set; }

        public List<CountryLanguage> CountryLanguages { get; set; }
    }
}
