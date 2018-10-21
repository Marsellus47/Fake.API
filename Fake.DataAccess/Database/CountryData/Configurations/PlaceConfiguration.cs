using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Fake.DataAccess.Database.CountryData.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasKey(place => place.Id);

            builder.HasData(Data.Countries
                .SelectMany(country => country.States)
                .SelectMany(state => state.Provinces)
                .SelectMany(province => province.Communities)
                .SelectMany(community => community.Places)
                .OrderBy(place => place.Id)
                .ToArray());
        }
    }
}
