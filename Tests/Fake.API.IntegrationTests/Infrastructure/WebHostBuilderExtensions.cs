using Fake.DataAccess.Database.CountryData;
using Fake.TestCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Fake.API.IntegrationTests.Infrastructure
{
    public static class WebHostBuilderExtensions
    {
        public static void ConfigureDatabaseForIntegrationTesting(this IWebHostBuilder builder, bool seedData = true)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (ApplicationDbContext) using an in-memory
                // database for testing.
                var dbName = Guid.NewGuid().ToString();
                services.AddDbContext<CountryDataContext>(options =>
                {
                    options.UseInMemoryDatabase(dbName);
                    options.UseInternalServiceProvider(serviceProvider);
                });

                if(seedData)
                {
                    // Build the service provider.
                    var sp = services.BuildServiceProvider();

                    // Create a scope to obtain a reference to the database
                    // context (ApplicationDbContext).
                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<CountryDataContext>();
                        var logger = scopedServices
                            .GetRequiredService<ILogger<CountryDataContext>>();

                        try
                        {
                            TestHelper.SeedDataAsync(db).GetAwaiter().GetResult();
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, $@"An error occurred seeding the
                            database with integration test data. Error: {ex.Message}");
                        }
                    }
                }
            });
        }
    }
}
