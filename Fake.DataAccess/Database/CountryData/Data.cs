using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Fake.DataAccess.Database.CountryData.Models;
using FakeCountryData = CountryData;

namespace Fake.DataAccess.Database.CountryData
{
    public static class Data
    {
        private static readonly string SeedFolderPath = $@"{Directory.GetCurrentDirectory()}\..\Fake.DataAccess\Database\CountryData\Seed";
        private static readonly string CurrencyFilePath = Path.Combine(SeedFolderPath, "Currency.sql");
        private static readonly string LanguageFilePath = Path.Combine(SeedFolderPath, "Language.sql");
        private static readonly string CountryFilePath = Path.Combine(SeedFolderPath, "Country.sql");
        private static readonly string CountryLanguageFilePath = Path.Combine(SeedFolderPath, "CountryLanguage.sql");
        private static readonly string StateFilePath = Path.Combine(SeedFolderPath, "State.sql");
        private static readonly string ProvinceFilePath = Path.Combine(SeedFolderPath, "Province.sql");
        private static readonly string CommunityFilePath = Path.Combine(SeedFolderPath, "Community.sql");
        private static readonly string PlaceFilePath = Path.Combine(SeedFolderPath, "Place.sql");
        private static readonly NumberFormatInfo DecimalNumberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };

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
                            LanguageId = languages[language]
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

            CountryLanguages = Countries
                .SelectMany(country => country.CountryLanguages)
                .GroupBy(countryLanguage => new { countryLanguage.CountryId, countryLanguage.LanguageId })
                .Select(group => new CountryLanguage { CountryId = group.Key.CountryId, LanguageId = group.Key.LanguageId })
                .OrderBy(countrylanguage => countrylanguage.CountryId)
                .ThenBy(countrylanguage => countrylanguage.LanguageId)
                .ToList();

            GenerateMissingPrimaryKeys();
        }

        public static string ToDbValue(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "null";

            return $"N'{value.Replace("'", "''")}'";
        }

        public static List<Currency> Currencies { get; } = new List<Currency>();
        public static List<Language> Languages { get; } = new List<Language>();
        public static List<Country> Countries { get; } = new List<Country>();
        public static List<CountryLanguage> CountryLanguages { get; } = new List<CountryLanguage>();
        public static List<State> States { get; } = new List<State>();
        public static List<Province> Provinces { get; } = new List<Province>();
        public static List<Community> Communities { get; } = new List<Community>();
        public static List<Place> Places { get; } = new List<Place>();

        private static void GenerateMissingPrimaryKeys()
        {
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
                    States.Add(countryState.state);

                    countryState.state.Provinces
                        .OrderBy(province => province.Name)
                        .ToList()
                        .ForEach(province =>
                        {
                            province.Id = ++provinceId;
                            province.StateId = countryState.state.Id;
                            Provinces.Add(province);

                            province.Communities
                                .OrderBy(community => community.Name)
                                .ToList()
                                .ForEach(community =>
                                {
                                    community.Id = ++communityId;
                                    community.ProvinceId = province.Id;
                                    Communities.Add(community);

                                    community.Places
                                        .OrderBy(place => place.Name)
                                        .ToList()
                                        .ForEach(place =>
                                        {
                                            place.Id = ++placeId;
                                            place.CommunityId = community.Id;
                                            Places.Add(place);
                                        });
                                });
                        });
                });
        }

        public static void WriteQueriesToFiles()
        {
            Directory.CreateDirectory(SeedFolderPath);
            using (var currencyFile = new StreamWriter(CurrencyFilePath))
            {
                currencyFile.WriteLine(SetIdentityInsert(nameof(Currency), true));
                currencyFile.WriteLine(CurrencyInsertClause);
                Currencies.ForEach(currency => currencyFile.WriteLine(currency.Id == 1 ? FormatCurrencyValues(currency) : $"union all {FormatCurrencyValues(currency)}"));
                currencyFile.WriteLine(SetIdentityInsert(nameof(Currency), false));
            }

            using (var languageFile = new StreamWriter(LanguageFilePath))
            {
                languageFile.WriteLine(SetIdentityInsert(nameof(Language), true));
                languageFile.WriteLine(LanguageInsertClause);
                Languages.ForEach(language => languageFile.WriteLine(language.Id == 1 ? FormatLanguageValues(language) : $"union all {FormatLanguageValues(language)}"));
                languageFile.WriteLine(SetIdentityInsert(nameof(Language), false));
            }

            using (var countryFile = new StreamWriter(CountryFilePath))
            {
                countryFile.WriteLine(SetIdentityInsert(nameof(Country), true));
                countryFile.WriteLine(CountryInsertClause);
                Countries.ForEach(country => countryFile.WriteLine(country.Id == 1 ? FormatCountryValues(country) : $"union all {FormatCountryValues(country)}"));
                countryFile.WriteLine(SetIdentityInsert(nameof(Country), false));
            }

            using (var countryLanguageFile = new StreamWriter(CountryLanguageFilePath))
            {
                countryLanguageFile.WriteLine(CountryLanguageInsertClause);
                CountryLanguages.Select((countrylanguage, index) => new { countrylanguage, index }).ToList().ForEach(x => countryLanguageFile.WriteLine(
                    x.index == 0 ? FormatCountryLanguageValues(x.countrylanguage) : $"union all {FormatCountryLanguageValues(x.countrylanguage)}"));
            }

            using (var stateFile = new StreamWriter(StateFilePath))
            {
                stateFile.WriteLine(SetIdentityInsert(nameof(State), true));
                stateFile.WriteLine(StateInsertClause);
                States.ForEach(state => stateFile.WriteLine(state.Id == 1 ? FormatStateValues(state) : $"union all {FormatStateValues(state)}"));
                stateFile.WriteLine(SetIdentityInsert(nameof(State), false));
            }

            using (var provinceFile = new StreamWriter(ProvinceFilePath))
            {
                provinceFile.WriteLine(SetIdentityInsert(nameof(Province), true));
                provinceFile.WriteLine(ProvinceInsertClause);
                Provinces.ForEach(province => provinceFile.WriteLine(province.Id == 1 ? FormatProvinceValues(province) : $"union all {FormatProvinceValues(province)}"));
                provinceFile.WriteLine(SetIdentityInsert(nameof(Province), false));
            }

            using (var communityFile = new StreamWriter(CommunityFilePath))
            {
                communityFile.WriteLine(SetIdentityInsert(nameof(Community), true));
                communityFile.WriteLine(CommunityInsertClause);
                Communities.ForEach(community => communityFile.WriteLine(community.Id == 1 ? FormatCommunityValues(community) : $"union all {FormatCommunityValues(community)}"));
                communityFile.WriteLine(SetIdentityInsert(nameof(Community), false));
            }

            using (var placeFile = new StreamWriter(PlaceFilePath))
            {
                placeFile.WriteLine(SetIdentityInsert(nameof(Place), true));
                placeFile.WriteLine(PlaceInsertClause);
                Places.ForEach(place => placeFile.WriteLine(place.Id == 1 ? FormatPlaceValues(place) : $"union all {FormatPlaceValues(place)}"));
                placeFile.WriteLine(SetIdentityInsert(nameof(Place), false));
            }
        }

        private static string SetIdentityInsert(string table, bool enable)
            => $"set identity_insert {table} {(enable ? " on" : " off")}";

        private static string CurrencyInsertClause
            => $"insert into {nameof(Currency)}({nameof(Currency.Id)}, {nameof(Currency.Name)}, {nameof(Currency.Code)})";

        private static string FormatCurrencyValues(Currency currency)
            => $"select {currency.Id}, {currency.Name.ToDbValue()}, {currency.Code.ToDbValue()}";

        private static string LanguageInsertClause
            => $"insert into {nameof(Language)}({nameof(Language.Id)}, {nameof(Language.Code)})";

        private static string FormatLanguageValues(Language language)
            => $"select {language.Id}, {language.Code.ToDbValue()}";

        private static string CountryInsertClause
            => $"insert into {nameof(Country)}({nameof(Country.Id)}, {nameof(Country.Name)}, {nameof(Country.PostCodeRegex)}, {nameof(Country.PostCodeFormat)}, {nameof(Country.PhonePrefix)}, {nameof(Country.TopLevelDomain)}, {nameof(Country.Continent)}, {nameof(Country.Area)}, {nameof(Country.Capital)}, {nameof(Country.Fips)}, {nameof(Country.IsoNumeric)}, {nameof(Country.Iso3)}, {nameof(Country.Iso)}, {nameof(Country.Population)}, {nameof(Country.CurrencyId)})";

        private static string FormatCountryValues(Country country)
            => $"select {country.Id}, {country.Name.ToDbValue()}, {country.PostCodeRegex.ToDbValue()}, {country.PostCodeFormat.ToDbValue()}, {country.PhonePrefix.ToDbValue()}, {country.TopLevelDomain.ToDbValue()}, {country.Continent.ToDbValue()}, {country.Area.ToString(DecimalNumberFormatInfo)}, {country.Capital.ToDbValue()}, {country.Fips.ToDbValue()}, {country.IsoNumeric}, {country.Iso3.ToDbValue()}, {country.Iso.ToDbValue()}, {country.Population}, {country.CurrencyId}";

        private static string CountryLanguageInsertClause
            => $"insert into {nameof(CountryLanguage)}({nameof(CountryLanguage.CountryId)}, {nameof(CountryLanguage.LanguageId)})";

        private static string FormatCountryLanguageValues(CountryLanguage countryLanguage)
            => $"select {countryLanguage.CountryId}, {countryLanguage.LanguageId}";

        private static string StateInsertClause
            => $"insert into {nameof(State)}({nameof(State.Id)}, {nameof(State.Name)}, {nameof(State.Code)}, {nameof(State.CountryId)})";

        private static string FormatStateValues(State state)
            => $"select {state.Id}, {state.Name.ToDbValue()}, {state.Code.ToDbValue()}, {state.CountryId}";

        private static string ProvinceInsertClause
            => $"insert into {nameof(Province)}({nameof(Province.Id)}, {nameof(Province.Name)}, {nameof(Province.Code)}, {nameof(Province.StateId)})";

        private static string FormatProvinceValues(Province province)
            => $"select {province.Id}, {province.Name.ToDbValue()}, {province.Code.ToDbValue()}, {province.StateId}";

        private static string CommunityInsertClause
            => $"insert into {nameof(Community)}({nameof(Community.Id)}, {nameof(Community.Name)}, {nameof(Community.Code)}, {nameof(Community.ProvinceId)})";

        private static string FormatCommunityValues(Community community)
            => $"select {community.Id}, {community.Name.ToDbValue()}, {community.Code.ToDbValue()}, {community.ProvinceId}";

        private static string PlaceInsertClause
            => $"insert into {nameof(Place)}({nameof(Place.Id)}, {nameof(Place.Name)}, {nameof(Place.PostCode)}, {nameof(Place.LatLong)}, {nameof(Place.CommunityId)})";

        private static string FormatPlaceValues(Place place)
            => $"select {place.Id}, {place.Name.ToDbValue()}, {place.PostCode.ToDbValue()}, {place.LatLong.ToDbValue()}, {place.CommunityId}";
    }
}
