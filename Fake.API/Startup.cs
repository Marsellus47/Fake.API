﻿using Fake.API.GraphQL.Types.CountryData;
using Fake.API.GraphQL.Types;
using Fake.DataAccess.Database.CountryData.Repositories;
using Fake.DataAccess.Database.CountryData;
using Fake.DataAccess.Interfaces.Random;
using Fake.DataAccess.Random;
using GraphQL.Http;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            #region GraphQL

            services.AddGraphQL(options => options.ExposeExceptions = true);

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddScoped<GraphQL.Infrastructure.GraphQLQuery>();
            services.AddScoped<ISchema, GraphQL.Infrastructure.GraphQLSchema>();

            services.AddScoped<RandomGroupGraphType>();
            services.AddScoped<CurrencyType>();
            services.AddScoped<LanguageType>();
            services.AddScoped<CountryType>();
            services.AddScoped<StateType>();
            services.AddScoped<CountryDataGraphType>();

            #endregion

            #region Data access

            const string countryDataConnectionString = @"Server=(localdb)\mssqllocaldb;Database=Fake.API.CountryData;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CountryDataContext>(options => options.UseSqlServer(countryDataConnectionString));

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
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
