﻿using Fake.DataAccess.Database.CountryData.Repositories;
using Fake.DataAccess.Database.CountryData;
using Fake.DataAccess.Interfaces.Random;
using Fake.DataAccess.Random;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Fake.API.Extensions;

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
            services.AddFakeApiGraphQL();

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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<ISchema>("/graphql");
            app.UseGraphiQLServer(new GraphiQLOptions());

            app.UseMvc();
        }
    }
}
