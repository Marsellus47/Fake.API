using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Fake.DataAccess.Database.CountryData.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(country => country.Id);

            builder.HasData(Data.Countries
                .SelectMany(country => country.States)
                .SelectMany(state => state.Provinces)
                .OrderBy(province => province.Id)
                .ToArray());
        }
    }
}
