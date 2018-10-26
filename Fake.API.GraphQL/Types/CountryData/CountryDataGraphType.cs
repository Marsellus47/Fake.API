using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class CountryDataGraphType : ObjectGraphType
    {
        public CountryDataGraphType(
            ICountryRepository countryRepository,
            ICurrencyRepository currencyRepository,
            ILanguageRepository languageRepository,
            IStateRepository stateRepository)
        {
            #region Currency

            FieldAsync<CurrencyType>(
                name: "currency",
                description: "Currency",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code", Description = "Currency code" }),
                resolve: async(context) =>
                {
                    var code = context.GetArgument<string>("code");
                    return await currencyRepository.GetCurrencyByCodeAsync(code);
                });

            FieldAsync<ListGraphType<CurrencyType>>(
                "currencies",
                resolve: async (context) => await currencyRepository.GetCurrenciesAsync());

            #endregion

            #region Language

            FieldAsync<LanguageType>(
                name: "language",
                description: "Language",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code", Description = "Language code" }),
                resolve: async (context) =>
                {
                    var code = context.GetArgument<string>("code");
                    return await languageRepository.GetLanguageByCodeAsync(code);
                });

            FieldAsync<ListGraphType<LanguageType>>(
                "languages",
                resolve: async (context) => await languageRepository.GetLanguagesAsync());

            #endregion

            #region Country

            FieldAsync<CountryType>(
                name: "country",
                description: "Country",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name", Description = "Country name" }),
                resolve: async (context) =>
                {
                    var name = context.GetArgument<string>("name");
                    return await countryRepository.GetCountryByNameAsync(name);
                });

            FieldAsync<ListGraphType<CountryType>>(
                "countries",
                resolve: async (context) => await countryRepository.GetCountriesAsync());

            #endregion

            #region State

            FieldAsync<StateType>(
                name: "state",
                description: "State",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code", Description = "State code" }),
                resolve: async (context) =>
                {
                    var code = context.GetArgument<string>("code");
                    return await stateRepository.GetStateByCodeAsync(code);
                });

            FieldAsync<ListGraphType<StateType>>(
                "states",
                resolve: async (context) => await stateRepository.GetStatesAsync());

            #endregion
        }
    }
}
