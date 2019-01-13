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
    public class StateInputGroupGraphType : ObjectGraphType
    {
        public StateInputGroupGraphType(IStateRepository stateRepository)
        {
            FieldAsync<NonNullGraphType<StateType>>(
                "insert",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StateInsertInputType>> { Name = "state" }),
                resolve: async (context) =>
                {
                    var state = context.GetArgument<State>("state");
                    await stateRepository.InsertAsync(state);
                    return state;
                });

            FieldAsync<StateType>(
                "update",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StateUpdateInputType>> { Name = "state" }),
                resolve: async (context) =>
                {
                    var state = context.GetArgument<State>("state");
                    await stateRepository.UpdateAsync(state);
                    return state;
                });

            FieldAsync<StateType>(
                "partialUpdate",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StatePartialUpdateInputType>> { Name = "state" }),
                resolve: async (context) =>
                {
                    var values = context.Arguments["state"] as IDictionary<string, object>;

                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(State.Name));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(State.Code));
                    context.AddErrorWhenSemiMandatoryFieldNull(values, nameof(State.CountryId));

                    if (context.Errors.Any())
                        return null;

                    return await stateRepository.PartiallyUpdateAsync(values);
                });

            FieldAsync<NonNullGraphType<BooleanGraphType>>(
                "delete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = nameof(State.Id).Camelize() }),
                resolve: async (context) =>
                {
                    var id = context.GetArgument<int>(nameof(State.Id).Camelize());
                    return await stateRepository.DeleteAsync(id);
                });
        }
    }
}
