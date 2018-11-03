using Fake.DataAccess.Database.CountryData;
using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryDataEF
{
    public class CountryDataEFGroupGraphType : EfObjectGraphType
    {
        public CountryDataEFGroupGraphType(
            IEfGraphQLService efGraphQLService,
            CountryDataContext countryDataContext)
            : base(efGraphQLService)
        {
            #region Currency

            AddQueryField<CurrencyEFType, Currency>(
                "currencies",
                resolve: context => countryDataContext.Currency);

            AddQueryConnectionField<CurrencyEFType, Currency>(
                "currenciesConnection",
                resolve: context => countryDataContext.Currency);

            #endregion

            #region Language

            AddQueryField<LanguageEFType, Language>(
                "languages",
                resolve: context => countryDataContext.Language);

            AddQueryConnectionField<LanguageEFType, Language>(
                "languagesConnection",
                resolve: context => countryDataContext.Language);

            #endregion

            #region Country

            AddQueryField<CountryEFType, Country>(
                "countries",
                resolve: context => countryDataContext.Country);

            AddQueryConnectionField<CountryEFType, Country>(
                "countriesConnection",
                resolve: context => countryDataContext.Country);

            #endregion

            #region State

            AddQueryField<StateEFType, State>(
                "states",
                resolve: context => countryDataContext.State);

            AddQueryConnectionField<StateEFType, State>(
                "statesConnection",
                resolve: context => countryDataContext.State);

            #endregion

            #region Province

            AddQueryField<ProvinceEFType, Province>(
                "provinces",
                resolve: context => countryDataContext.Province);

            AddQueryConnectionField<ProvinceEFType, Province>(
                "provincesConnection",
                resolve: context => countryDataContext.Province);

            #endregion

            #region Community

            AddQueryField<CommunityEFType, Community>(
                "communities",
                resolve: context => countryDataContext.Community);

            AddQueryConnectionField<CommunityEFType, Community>(
                "communitiesConnection",
                resolve: context => countryDataContext.Community);

            #endregion

            #region Place

            AddQueryField<PlaceEFType, Place>(
                "places",
                resolve: context => countryDataContext.Place);

            AddQueryConnectionField<PlaceEFType, Place>(
                "placesConnection",
                resolve: context => countryDataContext.Place);

            #endregion
        }
    }
}
