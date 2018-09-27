using Fake.DataAccess.Interfaces.Random;
using GraphQL.Types;

namespace Fake.API.GraphQL.Infrastructure
{
    public class GraphQLQuery : ObjectGraphType
    {
        public GraphQLQuery(IRandomScalarProvider randomScalarProvider)
        {
            #region Number

            Field<IntGraphType>(
                name: "Number",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value to generate", DefaultValue = int.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value to generate", DefaultValue = int.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var min = ctx.GetArgument<int>("min");
                    var max = ctx.GetArgument<int>("max");
                    return randomScalarProvider.Number(min: min, max: max);
                });

            Field<ListGraphType<IntGraphType>>(
                name: "Numbers",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "count", Description = "Number of values to generate" },
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value to generate",  DefaultValue = int.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value to generate", DefaultValue = int.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var count = (short)ctx.GetArgument<int>("count");
                    var min = ctx.GetArgument<int>("min");
                    var max = ctx.GetArgument<int>("max");
                    return randomScalarProvider.Numbers(count: count, min: min, max: max);
                });

            #endregion Number
        }
    }
}
