using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class ProvinceUpdateInputType : InputObjectGraphType<Province>
    {
        public ProvinceUpdateInputType()
        {
            Field(country => country.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(country => country.Name);
            Field(country => country.Code);
            Field(country => country.StateId);
        }
    }
}
