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
            builder.HasKey(province => province.Id);

            builder.HasData(Data.Countries
                .SelectMany(country => country.States)
                .SelectMany(state => state.Provinces)
                .OrderBy(province => province.Id)
                .Select(province => new
                {
                    province.Id,
                    province.Name,
                    province.Code,
                    province.StateId
                })
                .ToArray());
        }
    }
}
