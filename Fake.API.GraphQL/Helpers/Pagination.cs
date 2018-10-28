using GraphQL.Types;

namespace Fake.API.GraphQL.Helpers
{
    public static class Pagination
    {
        private const int defaultPageNumber = 1;
        private const int defaultPageSize = 50;

        private static readonly QueryArgument<IntGraphType> pageNumberArgumnent;
        private static readonly QueryArgument<IntGraphType> pageSizeArgumnent;

        static Pagination()
        {
            pageNumberArgumnent = new QueryArgument<IntGraphType> { Name = "pageNumber", Description = "Page number", DefaultValue = defaultPageNumber };
            pageSizeArgumnent = new QueryArgument<IntGraphType> { Name = "pageSize", Description = "Page size", DefaultValue = defaultPageSize };
        }

        public static QueryArgument[] QueryArguments
            => new[]
            {
                pageNumberArgumnent,
                pageSizeArgumnent
            };

        public static PaginationValues ParseArguments(ResolveFieldContext<object> context)
        {
            int pageNumber = context.GetArgument<int>(pageNumberArgumnent.Name);
            int pageSize = context.GetArgument<int>(pageSizeArgumnent.Name);

            return new PaginationValues
            {
                PageNumber = pageNumber < defaultPageNumber ? defaultPageNumber : pageNumber,
                PageSize = pageSize > defaultPageSize ? defaultPageSize : pageSize
            };
        }
    }

    public class PaginationValues
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
