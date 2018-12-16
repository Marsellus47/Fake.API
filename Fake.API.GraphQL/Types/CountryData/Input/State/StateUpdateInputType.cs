using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class StateUpdateInputType : InputObjectGraphType<State>
    {
        public StateUpdateInputType()
        {
            Field(state => state.Id, type: typeof(NonNullGraphType<IdGraphType>));
            Field(state => state.Name);
            Field(state => state.Code);
            Field(state => state.CountryId);
        }
    }
}
