using Fake.API.GraphQL.Helpers;
using Fake.API.GraphQL.Types.CountryData.Output;
using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;
using Humanizer;
using System.Collections.Generic;
using System.Linq;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class CountryInputGroupGraphType : ObjectGraphType
    {
        public CountryInputGroupGraphType(ICountryRepository countryRepository)
        {
            FieldAsync<NonNullGraphType<CountryType>>(
                "insert",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CountryInsertInputType>> { Name = "country" }),
                resolve: async (context) =>
                {
                    var country = context.GetArgument<Country>("country");
                    await countryRepository.InsertAsync(country);
                    return country;
                });

            FieldAsync<CountryType>(
                "update",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CountryUpdateInputType>> { Name = "country" }),
                resolve: async (context) =>
                {
                    var country = context.GetArgument<Country>("country");
                    return await countryRepository.UpdateAsync(country);
                });

            FieldAsync<CountryType>(
                "partialUpdate",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CountryPartialUpdateInputType>> { Name = "country" }),
                resolve: async (context) =>
                {
                    var values = context.Arguments["country"] as IDictionary<string, object>;

                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.Name));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.PostCodeFormat));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.PostCodeRegex));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.PhonePrefix));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.TopLevelDomain));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.Continent));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.Area));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.Capital));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.IsoNumeric));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.Iso3));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.Iso));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(Country.CurrencyId));

                    if (context.Errors.Any())
                        return null;

                    return await countryRepository.PartiallyUpdateAsync(values);
                });

            FieldAsync<NonNullGraphType<BooleanGraphType>>(
                "delete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = nameof(Country.Id).Camelize() }),
                resolve: async (context) =>
                {
                    var id = context.GetArgument<int>(nameof(Country.Id).Camelize());
                    return await countryRepository.DeleteAsync(id);
                });
        }
    }
}
