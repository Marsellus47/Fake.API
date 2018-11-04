using Fake.API.GraphQL.Infrastructure.Arguments;
using Fake.API.GraphQL.Infrastructure.Extensions;
using GraphQL.Types;

namespace Fake.API.GraphQL.Helpers
{
    public static class Pagination
    {
        private const int PAGE_NUMBER_DEFAULT = 1;
        private const int PAGE_NUMBER_MIN = 1;
        private const int PAGE_SIZE_DEFAULT = 50;
        private const int PAGE_SIZE_MIN = 1;
        private const int PAGE_SIZE_MAX = 50;

        private static readonly NumericArgument pageNumberArgumnent;
        private static readonly NumericArgument pageSizeArgumnent;

        static Pagination()
        {
            pageNumberArgumnent = new NumericArgument { Name = "pageNumber", Description = "Page number", DefaultValue = PAGE_NUMBER_DEFAULT };
            pageSizeArgumnent = new NumericArgument { Name = "pageSize", Description = "Page size", DefaultValue = PAGE_SIZE_DEFAULT };
        }

        public static QueryArgument[] QueryArguments
            => new[]
            {
                pageNumberArgumnent.GreaterThanOrEqual(PAGE_NUMBER_MIN),
                pageSizeArgumnent.GreaterThanOrEqual(PAGE_SIZE_MIN).LowerThanOrEqual(PAGE_SIZE_MAX)
            };

        public static PaginationValues ParseArguments(ResolveFieldContext<object> context)
        {
            int pageNumber = context.GetArgument<int>(pageNumberArgumnent.Name);
            int pageSize = context.GetArgument<int>(pageSizeArgumnent.Name);

            return new PaginationValues
            {
                PageNumber = pageNumber < PAGE_NUMBER_DEFAULT ? PAGE_NUMBER_DEFAULT : pageNumber,
                PageSize = pageSize > PAGE_SIZE_DEFAULT ? PAGE_SIZE_DEFAULT : pageSize
            };
        }
    }

    public class PaginationValues
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
