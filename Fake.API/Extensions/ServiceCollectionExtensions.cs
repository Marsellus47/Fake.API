using Fake.API.GraphQL.Infrastructure;
using Fake.API.GraphQL.Infrastructure.Validation;
using Fake.API.GraphQL.Types;
using Fake.API.GraphQL.Types.CountryData.Input;
using Fake.API.GraphQL.Types.CountryData.Output;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Execution;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Fake.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFakeApiGraphQL(this IServiceCollection services)
        {
            services.AddGraphQL(options => options.ExposeExceptions = true);

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<IDocumentExecutionListener, DataLoaderDocumentListener>();

            services.AddScoped<ISchema, FakeApiSchema>();
            services.AddScoped<FakeApiQuery>();
            services.AddScoped<FakeApiMutation>();
            services.AddSingleton<IValidationRule, ArgumentValueLowerThanOrEqual>();
            services.AddSingleton<IValidationRule, ArgumentValueHigherThanOrEqual>();

            services.AddScoped<RandomGroupGraphType>();

            services.AddScoped<CountryDataOutputGroupGraphType>();
            services.AddScoped<CommunityType>();
            services.AddScoped<CountryType>();
            services.AddScoped<CurrencyType>();
            services.AddScoped<LanguageType>();
            services.AddScoped<PlaceType>();
            services.AddScoped<ProvinceType>();
            services.AddScoped<StateType>();

            services.AddScoped<CountryDataInputGroupGraphType>();

            services.AddScoped<CurrencyInputGroupGraphType>();
            services.AddScoped<CurrencyInsertInputType>();
            services.AddScoped<CurrencyUpdateInputType>();
            services.AddScoped<CurrencyPartialUpdateInputType>();

            services.AddScoped<LanguageInputGroupGraphType>();
            services.AddScoped<LanguageInsertInputType>();
            services.AddScoped<LanguageUpdateInputType>();

            services.AddScoped<CountryInputGroupGraphType>();
            services.AddScoped<CountryInsertInputType>();
            services.AddScoped<CountryUpdateInputType>();
            services.AddScoped<CountryPartialUpdateInputType>();

            services.AddScoped<StateInputGroupGraphType>();
            services.AddScoped<StateInsertInputType>();
            services.AddScoped<StateUpdateInputType>();
            services.AddScoped<StatePartialUpdateInputType>();

            services.AddScoped<ProvinceInputGroupGraphType>();
            services.AddScoped<ProvinceInsertInputType>();
            services.AddScoped<ProvinceUpdateInputType>();
            services.AddScoped<ProvincePartialUpdateInputType>();

            services.AddScoped<CommunityInputGroupGraphType>();
            services.AddScoped<CommunityInsertInputType>();
            services.AddScoped<CommunityUpdateInputType>();
            services.AddScoped<CommunityPartialUpdateInputType>();

            services.AddScoped<PlaceInputGroupGraphType>();
            services.AddScoped<PlaceInsertInputType>();
            services.AddScoped<PlaceUpdateInputType>();
            services.AddScoped<PlacePartialUpdateInputType>();
        }
    }
}
