using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Fake.DataAccess.Database.CountryData.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(country => country.Id);

            builder.HasData(Data.Countries
                .Select(country => new
                {
                    Id = country.Id,
                    Name = country.Name,
                    PostCodeRegex = country.PostCodeRegex,
                    PostCodeFormat = country.PostCodeFormat,
                    PhonePrefix = country.PhonePrefix,
                    TopLevelDomain = country.TopLevelDomain,
                    Continent = country.Continent,
                    Area = country.Area,
                    Capital = country.Capital,
                    Fips = country.Fips,
                    IsoNumeric = country.IsoNumeric,
                    Iso3 = country.Iso3,
                    Iso = country.Iso,
                    Population = country.Population,
                    CurrencyId = country.CurrencyId
                })
                .ToArray());
        }
    }
}
