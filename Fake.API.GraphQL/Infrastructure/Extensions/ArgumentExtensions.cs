using Fake.API.GraphQL.Infrastructure.Arguments;

namespace Fake.API.GraphQL.Infrastructure.Extensions
{
    public static class ArgumentExtensions
    {
        public static NumericArgument GreaterThanOrEqual(this NumericArgument argument, int value)
        {
            argument.Metadata[NumericArgument.MinValueMetadataName] = value;
            return argument;
        }

        public static NumericArgument LowerThanOrEqual(this NumericArgument argument, int value)
        {
            argument.Metadata[NumericArgument.MaxValueMetadataName] = value;
            return argument;
        }
    }
}
