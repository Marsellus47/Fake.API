using Fake.DataAccess.Database.CountryData.Configurations;
using Fake.DataAccess.Database.CountryData.Models;
using Microsoft.EntityFrameworkCore;

namespace Fake.DataAccess.Database.CountryData
{
    public class CountryDataContext : DbContext
    {
        public CountryDataContext(DbContextOptions<CountryDataContext> options)
            : base(options) { }

        public DbSet<Currency> Currencies { get; set; }
        //public DbSet<Language> Languages { get; set; }
        //public DbSet<Country> Country { get; set; }
        //public DbSet<CountryLanguage> CountryLanguages { get; set; }
        //public DbSet<State> States { get; set; }
        //public DbSet<Province> Provinces { get; set; }
        //public DbSet<Community> Communities { get; set; }
        //public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            //modelBuilder.ApplyConfiguration(new LanguageConfiguration());
        }
    }
}
