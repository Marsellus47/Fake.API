﻿// <auto-generated />
using Fake.DataAccess.Database.CountryData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fake.DataAccess.Database.CountryData.Migrations
{
    [DbContext(typeof(CountryDataContext))]
    partial class CountryDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.Community", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<int>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Community");
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Area");

                    b.Property<string>("Capital");

                    b.Property<string>("Continent");

                    b.Property<int>("CurrencyId");

                    b.Property<string>("Fips");

                    b.Property<string>("Iso");

                    b.Property<string>("Iso3");

                    b.Property<int>("IsoNumeric");

                    b.Property<string>("Name");

                    b.Property<string>("PhonePrefix");

                    b.Property<long>("Population");

                    b.Property<string>("PostCodeFormat");

                    b.Property<string>("PostCodeRegex");

                    b.Property<string>("TopLevelDomain");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.CountryLanguage", b =>
                {
                    b.Property<int>("CountryId");

                    b.Property<int>("LanguageId");

                    b.HasKey("CountryId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("CountryLanguage");
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommunityId");

                    b.Property<string>("LatLong");

                    b.Property<string>("Name");

                    b.Property<string>("PostCode");

                    b.HasKey("Id");

                    b.HasIndex("CommunityId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<int>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.Community", b =>
                {
                    b.HasOne("Fake.DataAccess.Database.CountryData.Models.Province", "Province")
                        .WithMany("Communities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.Country", b =>
                {
                    b.HasOne("Fake.DataAccess.Database.CountryData.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.CountryLanguage", b =>
                {
                    b.HasOne("Fake.DataAccess.Database.CountryData.Models.Country", "Country")
                        .WithMany("CountryLanguages")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fake.DataAccess.Database.CountryData.Models.Language", "Language")
                        .WithMany("CountryLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.Place", b =>
                {
                    b.HasOne("Fake.DataAccess.Database.CountryData.Models.Community", "Community")
                        .WithMany("Places")
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.Province", b =>
                {
                    b.HasOne("Fake.DataAccess.Database.CountryData.Models.State", "State")
                        .WithMany("Provinces")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fake.DataAccess.Database.CountryData.Models.State", b =>
                {
                    b.HasOne("Fake.DataAccess.Database.CountryData.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
