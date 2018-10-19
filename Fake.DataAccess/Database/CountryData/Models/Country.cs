using System.Collections.Generic;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostCodeRegex { get; set; }
        public string PostCodeFormat { get; set; }
        public string PhonePrefix { get; set; }
        public string TopLevelDomain { get; set; }
        public string Continent { get; set; }
        public double Area { get; set; }
        public string Capital { get; set; }
        public string Fips { get; set; }
        public ushort IsoNumeric { get; set; }
        public string Iso3 { get; set; }
        public string Iso { get; set; }
        public uint Population { get; set; }
        //public List<State> States { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        //public List<CountryLanguage> CountryLanguages { get; set; }
    }
}
