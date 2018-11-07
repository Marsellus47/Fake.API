using Fake.DataAccess.Database.Infrastructure.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Country : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PostCodeRegex { get; set; }

        [Required]
        public string PostCodeFormat { get; set; }

        [Required]
        public string PhonePrefix { get; set; }

        [Required]
        public string TopLevelDomain { get; set; }

        [Required]
        public string Continent { get; set; }

        [Required]
        public double Area { get; set; }

        [Required]
        public string Capital { get; set; }

        public string Fips { get; set; }

        [Required]
        public ushort IsoNumeric { get; set; }

        [Required]
        public string Iso3 { get; set; }

        [Required]
        public string Iso { get; set; }

        public uint Population { get; set; }

        public List<State> States { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public List<CountryLanguage> CountryLanguages { get; set; }
    }
}
