using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class StatePartialUpdateInputType : InputObjectGraphType<State>
    {
        public StatePartialUpdateInputType()
        {
            Field(state => state.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(state => state.Name, nullable: true);
            Field(state => state.Code, nullable: true);
            Field(state => state.CountryId, nullable: true);
        }
    }
}
