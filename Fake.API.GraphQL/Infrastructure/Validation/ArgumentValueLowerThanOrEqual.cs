using Fake.API.GraphQL.Infrastructure.Arguments;
using GraphQL.Language.AST;
using GraphQL.Validation;

namespace Fake.API.GraphQL.Infrastructure.Validation
{
    public class ArgumentValueLowerThanOrEqual : IValidationRule
    {
        public INodeVisitor Validate(ValidationContext context)
        {
            return new EnterLeaveListener(_ =>
            {
                _.Match<Argument>(argAst =>
                {
                    var argDef = context.TypeInfo.GetArgument() as NumericArgument;
                    if (argDef?.HasMetadata(NumericArgument.MaxValueMetadataName) != true
                        || argAst.Value.Value == null)
                    {
                        return;
                    }

                    var maxValue = argDef.GetMetadata<int>(NumericArgument.MaxValueMetadataName);
                    if ((int)argAst.Value.Value > maxValue)
                    {
                        var error = new ValidationError(
                            context.OriginalQuery,
                            "value-higher-than-max",
                            $"{argAst.Name} value has to be lower than or equal to {argDef.GetMetadata<int>(NumericArgument.MaxValueMetadataName)}",
                            argAst);
                        context.ReportError(error);
                    }
                });
            });
        }
    }
}
