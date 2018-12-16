using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class ProvinceInsertInputType : InputObjectGraphType<Province>
    {
        public ProvinceInsertInputType()
        {
            Field(country => country.Name);
            Field(country => country.Code);
            Field(country => country.StateId);
        }
    }
}
