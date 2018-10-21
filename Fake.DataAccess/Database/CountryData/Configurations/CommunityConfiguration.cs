using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Fake.DataAccess.Database.CountryData.Configurations
{
    public class CommunityConfiguration : IEntityTypeConfiguration<Community>
    {
        public void Configure(EntityTypeBuilder<Community> builder)
        {
            builder.HasKey(community => community.Id);

            builder.HasData(Data.Countries
                .SelectMany(country => country.States)
                .SelectMany(state => state.Provinces)
                .SelectMany(province => province.Communities)
                .OrderBy(community => community.Id)
                .ToArray());
        }
    }
}
