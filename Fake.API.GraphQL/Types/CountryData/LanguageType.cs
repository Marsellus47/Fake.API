using Fake.DataAccess.Database.CountryData.Models;
using Fake.DataAccess.Database.CountryData.Repositories;
using GraphQL.Types;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class LanguageType : ObjectGraphType<Language>
    {
        public LanguageType(ICountryRepository countryRepository)
        {
            Field(c => c.Id);
            Field(c => c.Code);
            Field<ListGraphType<CountryType>, IEnumerable<Country>>()
                .Name("countries")
                .ResolveAsync(ctx => countryRepository.GetCountriesByLanguageIdAsync(ctx.Source.Id));
        }
    }
}
