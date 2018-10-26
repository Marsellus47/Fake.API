using Fake.DataAccess.Database.CountryData.Models;
using GraphQL.Types;

namespace Fake.API.GraphQL.Types.CountryData
{
    public class StateType : ObjectGraphType<State>
    {
        public StateType()
        {
            Field(state => state.Id);
            Field(state => state.Name);
            Field(state => state.Code);
        }
    }
}
