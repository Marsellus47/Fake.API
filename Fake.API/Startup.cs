using Fake.API.Auth;
using Fake.API.Extensions;
using Fake.DataAccess.Database.CountryData.Repositories;
using Fake.DataAccess.Database.CountryData;
using Fake.DataAccess.Interfaces.Random;
using Fake.DataAccess.Random;
using GraphQL.Server;
using GraphQL.Types;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using GraphQL.Server.Ui.Playground;

namespace Fake.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<IdentityServerAuthenticationOptions>(Configuration.GetSection("IdentityServer"));

            services.AddFakeApiGraphQL();
            services.AddFakeApiAuth();

            #region Data access

            const string countryDataConnectionString = @"Server=(localdb)\mssqllocaldb;Database=Fake.API.CountryData;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CountryDataContext>(options => options
                .UseSqlServer(countryDataConnectionString)
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning)));

            services.AddScoped<ICommunityRepository, CommunityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IStateRepository, StateRepository>();

            #endregion

            services.AddScoped<IRandomScalarProvider, RandomScalarProvider>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

#if DEBUG
            IdentityModelEventSource.ShowPII = true;
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseGraphQLWebSockets<ISchema>("/graphql");
            app.UseGraphQL<ISchema>("/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseMvc();
        }
    }
}
