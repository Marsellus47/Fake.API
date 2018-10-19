using Fake.DataAccess.Database.CountryData.Models;
using System.Collections.Generic;
using System.Linq;
using FakeCountryData = CountryData;

namespace Fake.DataAccess.Database.CountryData
{
    public static class Data
    {
        static Data()
        {
            FakeCountryData.CountryLoader.LoadAll();
            var locations = FakeCountryData.CountryLoader.LoadedLocationData.Values;

            var currencies = locations
                .GroupBy(x => new { x.CurrencyCode, x.CurrencyName })
                .Select(x => new Currency
                {
                    Code = x.Key.CurrencyCode,
                    Name = x.Key.CurrencyName
                })
                .Distinct()
                .OrderBy(x => x.Code)
                .Select((currency, index) => new Currency
                {
                    Id = index + 1,
                    Code = currency.Code,
                    Name = currency.Name
                })
                .ToDictionary(x => x.Code, x => x);

            Currencies = currencies.Values.ToList();

            var languages = locations.SelectMany(x => x.Languages)
                .Distinct()
                .OrderBy(language => language)
                .Select((language, index) => new { language, index })
                .ToDictionary(x => x.language, x => x.index + 1);

            Languages = languages.Select(keyValue => new Language
            {
                Id = keyValue.Value,
                Code = keyValue.Key
            })
            .ToList();

            Countries = locations
                .OrderBy(x => x.Name)
                .Select((country, countryIndex) => new Country
                {
                    Id = countryIndex + 1,
                    Area = country.Area,
                    Capital = country.Capital,
                    Continent = country.Continent,
                    CurrencyId = currencies[country.CurrencyCode].Id,
                    Fips = country.Fips,
                    Iso = country.Iso,
                    Iso3 = country.Iso3,
                    IsoNumeric = country.IsoNumeric,
                    CountryLanguages = country.Languages
                        .Select(language => new CountryLanguage
                        {
                            CountryId = countryIndex + 1,
                            LanguageId = languages[language] + 1
                        })
                        .ToList(),
                    Name = country.Name,
                    PhonePrefix = country.PhonePrefix,
                    Population = country.Population,
                    PostCodeFormat = country.PostCodeFormat,
                    PostCodeRegex = country.PostCodeRegex,
                    States = country.States
                        .Where(state => !string.IsNullOrEmpty(state.Name))
                        .Select(state => new State
                        {
                            Code = state.Code,
                            Name = state.Name,
                            Provinces = state.Provinces
                                .Select(province => new Province
                                {
                                    Code = province.Code,
                                    Communities = province.Communities
                                        .Select(community => new Community
                                        {
                                            Code = community.Code,
                                            Name = community.Name,
                                            Places = community.Places
                                                .Select(place => new Place
                                                {
                                                    LatLong = place.LatLong,
                                                    Name = place.Name,
                                                    PostCode = place.PostCode
                                                })
                                                .ToList()
                                        })
                                        .ToList(),
                                    Name = province.Name
                                })
                                .ToList()
                        })
                        .ToList(),
                    TopLevelDomain = country.TopLevelDomain
                })
                .ToList();

            int stateId = 0;
            int provinceId = 0;
            int communityId = 0;
            int placeId = 0;

            Countries
                .SelectMany(x => x.States, (country, state) => new { country, state })
                .OrderBy(countryState => countryState.state.Name)
                .ToList()
                .ForEach(countryState =>
                {
                    countryState.state.Id = ++stateId;
                    countryState.state.CountryId = countryState.country.Id;

                    countryState.state.Provinces
                        .OrderBy(province => province.Name)
                        .ToList()
                        .ForEach(province =>
                        {
                            province.Id = ++provinceId;
                            province.StateId = countryState.state.Id;

                            province.Communities
                                .OrderBy(community => community.Name)
                                .ToList()
                                .ForEach(community =>
                                {
                                    community.Id = ++communityId;
                                    community.ProvinceId = province.Id;

                                    community.Places
                                        .OrderBy(place => place.Name)
                                        .ToList()
                                        .ForEach(place =>
                                        {
                                            place.Id = ++placeId;
                                            place.CommunityId = community.Id;
                                        });
                                });
                        });
                });
        }

        public static List<Currency> Currencies { get; set; }
        public static List<Language> Languages { get; set; }
        public static List<Country> Countries { get; }
    }
}
