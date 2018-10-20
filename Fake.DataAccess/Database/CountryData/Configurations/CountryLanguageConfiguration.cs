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
            builder.HasKey(x => new
            {
                x.CountryId,
                x.LanguageId
            });

            builder.HasData(Data.Countries
                .SelectMany(x => x.CountryLanguages)
                .GroupBy(x => new
                {
                    x.CountryId,
                    x.LanguageId
                })
                .Select(x => new
                {
                    x.Key.CountryId,
                    x.Key.LanguageId
                })
                .OrderBy(x => x.CountryId)
                .ThenBy(x => x.LanguageId)
                .ToArray());
        }
    }
}
