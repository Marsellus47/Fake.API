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
                    country.Id,
                    country.Name,
                    country.PostCodeRegex,
                    country.PostCodeFormat,
                    country.PhonePrefix,
                    country.TopLevelDomain,
                    country.Continent,
                    country.Area,
                    country.Capital,
                    country.Fips,
                    country.IsoNumeric,
                    country.Iso3,
                    country.Iso,
                    country.Population,
                    country.CurrencyId
                })
                .ToArray());
        }
    }
}
