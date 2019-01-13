using Fake.DataAccess.Database.CountryData;
using Fake.DataAccess.Database.CountryData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fake.TestCore
{
    public static class TestHelper
    {
        public const string CurrencyCode = "Currency code";
        public const string CurrencyName = "Currency name";
        public const string CountryName = "Country name";

        public static async Task SeedDataAsync(CountryDataContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            await SeedCountryDataAsync(dbContext);
        }

        private static async Task SeedCountryDataAsync(CountryDataContext dbContext)
        {
            await dbContext.AddAsync(new Country
            {
                Area = 1,
                Capital = "Country capital",
                Continent = "Country continent",
                CountryLanguages = new List<CountryLanguage>
                {
                    new CountryLanguage
                    {
                        Language = new Language
                        {
                            Code = "Language code"
                        }
                    }
                },
                Currency = new Currency
                {
                    Code = CurrencyCode,
                    Name = CurrencyName
                },
                Fips = "Country fips",
                Iso = "Country ISO",
                Iso3 = "Country ISO3",
                IsoNumeric = 1,
                Name = CountryName,
                PhonePrefix = "Country phone prefix",
                Population = 1000,
                PostCodeFormat = "Country post code format",
                PostCodeRegex = "Country post code regex",
                TopLevelDomain = "Country top level domain",
                States = new List<State>
                {
                    new State
                    {
                        Code = "State code",
                        Name = "State name",
                        Provinces = new List<Province>
                        {
                            new Province
                            {
                                Code = "Province code",
                                Name = "Province name",
                                Communities = new List<Community>
                                {
                                    new Community
                                    {
                                        Code = "Community code",
                                        Name = "Community name",
                                        Places = new List<Place>
                                        {
                                            new Place
                                            {
                                                Name = "Place name",
                                                LatLong = "Place lat long",
                                                PostCode = "Place post code"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
