using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Fake.DataAccess.Database.CountryData.Configurations
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(state => state.Id);

            builder.HasData(Data.Countries
                .SelectMany(country => country.States)
                .OrderBy(state => state.Id)
                .ToArray());
        }
    }
}
