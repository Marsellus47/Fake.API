﻿namespace Fake.DataAccess.Database.CountryData.Models
{
    public class CountryLanguage
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
