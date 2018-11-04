using Fake.DataAccess.Database.Infrastructure.Model;
using System.Collections.Generic;

namespace Fake.DataAccess.Database.CountryData.Models
{
    public class Language : Entity
    {
        public string Code { get; set; }

        public List<CountryLanguage> CountryLanguages { get; set; }
    }
}
