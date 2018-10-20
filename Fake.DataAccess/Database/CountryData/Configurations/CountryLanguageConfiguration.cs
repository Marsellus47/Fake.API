using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Fake.DataAccess.Database.CountryData.Configurations
{
    public class CountryLanguageConfiguration : IEntityTypeConfiguration<CountryLanguage>
    {
        public void Configure(EntityTypeBuilder<CountryLanguage> builder)
        {
            builder.HasKey(countryLanguage => new
            {
                countryLanguage.CountryId,
                countryLanguage.LanguageId
            });

            builder.HasData(Data.Countries
                .SelectMany(countryLanguage => countryLanguage.CountryLanguages)
                .GroupBy(countryLanguage => new
                {
                    countryLanguage.CountryId,
                    countryLanguage.LanguageId
                })
                .Select(group => new
                {
                    group.Key.CountryId,
                    group.Key.LanguageId
                })
                .OrderBy(x => x.CountryId)
                .ThenBy(x => x.LanguageId)
                .ToArray());
        }
    }
}
