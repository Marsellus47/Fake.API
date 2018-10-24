using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
