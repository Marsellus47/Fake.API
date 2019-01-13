using GraphQL;
using GraphQL.Types;
using Humanizer;
using System.Collections.Generic;

namespace Fake.API.GraphQL.Helpers
{
    public static class GraphQLExtensions
    {
        public static void AddErrorWhenSemiMandatoryFieldNull(this ResolveFieldContext<object> context, IDictionary<string, object> values, string fieldName)
        {
            if (values.TryGetValue(fieldName.Camelize(), out object fieldValue) && fieldValue == null)
            {
                context.Errors.Add(new ExecutionError($"{fieldName.Camelize()} cannot be null when listed, omit {fieldName.Camelize()} if you don't want to update it"));
            }
        }
    }
}
