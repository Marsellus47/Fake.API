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
        public DbSet<Language> Languages { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<CountryLanguage> CountryLanguages { get; set; }
        public DbSet<State> State { get; set; }
        //public DbSet<Province> Province { get; set; }
        //public DbSet<Community> Community { get; set; }
        //public DbSet<Place> Place { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CountryLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
        }
    }
}
