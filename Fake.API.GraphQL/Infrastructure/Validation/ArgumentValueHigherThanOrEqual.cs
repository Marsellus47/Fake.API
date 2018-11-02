using Fake.API.GraphQL.Infrastructure.Arguments;
using GraphQL.Language.AST;
using GraphQL.Validation;

namespace Fake.API.GraphQL.Infrastructure.Validation
{
    public class ArgumentValueHigherThanOrEqual : IValidationRule
    {
        public INodeVisitor Validate(ValidationContext context)
        {
            return new EnterLeaveListener(_ =>
            {
                _.Match<Argument>(argAst =>
                {
                    var argDef = context.TypeInfo.GetArgument() as NumericArgument;
                    if (argDef?.HasMetadata(NumericArgument.MinValueMetadataName) != true
                        || argAst.Value.Value == null)
                    {
                        return;
                    }

                    var minValue = argDef.GetMetadata<int>(NumericArgument.MinValueMetadataName);
                    if ((int)argAst.Value.Value < minValue)
                    {
                        var error = new ValidationError(
                            context.OriginalQuery,
                            "value-lower-than-min",
                            $"{argAst.Name} value has to be greater than or equal to {argDef.GetMetadata<int>(NumericArgument.MinValueMetadataName)}",
                            argAst);
                        context.ReportError(error);
                    }
                });
            });
        }
    }
}
