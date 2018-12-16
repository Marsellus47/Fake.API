using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData.Input
{
    public class StateInsertInputType : InputObjectGraphType<State>
    {
        public StateInsertInputType()
        {
            Field(state => state.Name);
            Field(state => state.Code);
            Field(state => state.CountryId);
        }
    }
}
