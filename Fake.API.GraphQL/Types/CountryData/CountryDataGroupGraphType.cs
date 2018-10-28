using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class CountryDataGroupGraphType : ObjectGraphType
    {
        public CountryDataGroupGraphType(
            ICountryRepository countryRepository,
            ICurrencyRepository currencyRepository,
            ILanguageRepository languageRepository,
            IProvinceRepository provinceRepository,
            IStateRepository stateRepository,
            ICommunityRepository communityRepository,
            IPlaceRepository placeRepository)
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

            #region Province

            FieldAsync<ProvinceType>(
                name: "province",
                description: "Province",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code", Description = "Province code" }),
                resolve: async (context) =>
                {
                    var code = context.GetArgument<string>("code");
                    return await provinceRepository.GetProvinceByCodeAsync(code);
                });

            FieldAsync<ListGraphType<ProvinceType>>(
                "provinces",
                resolve: async (context) => await provinceRepository.GetProvincesAsync());

            #endregion

            #region Community

            FieldAsync<CommunityType>(
                name: "community",
                description: "Community",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code", Description = "Community code" }),
                resolve: async (context) =>
                {
                    var code = context.GetArgument<string>("code");
                    return await communityRepository.GetCommunityByCodeAsync(code);
                });

            FieldAsync<ListGraphType<CommunityType>>(
                "communities",
                resolve: async (context) => await communityRepository.GetCommunitiesAsync());

            #endregion

            #region Place

            FieldAsync<PlaceType>(
                name: "place",
                description: "Place",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name", Description = "Place name" }),
                resolve: async (context) =>
                {
                    var name = context.GetArgument<string>("name");
                    return await placeRepository.GetPlaceByNameAsync(name);
                });

            FieldAsync<ListGraphType<PlaceType>>(
                "places",
                resolve: async (context) => await placeRepository.GetPlacesAsync());

            #endregion
        }
    }
}
