using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class ProvincePartialUpdateInputType : InputObjectGraphType<Province>
    {
        public ProvincePartialUpdateInputType()
        {
            Field(country => country.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(country => country.Name, nullable: true);
            Field(country => country.Code, nullable: true);
            Field(country => country.StateId, nullable: true);
        }
    }
}
