﻿using System.Linq;

namespace Fake.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int pageNumber, int pageSize)
        {
            return queryable
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
