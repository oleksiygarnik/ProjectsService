using Agile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Infrastructure.QueryHandlers.Users
{
    public static class QueryableFilterExtensions
    {
        public static IQueryable<User> SortUserByFirstname(this IQueryable<User> query, SortDirection sortDirection)
        {
            return sortDirection == SortDirection.Asending
                ? query.OrderBy(u => u.FirstName)
                : query.OrderByDescending(u => u.FirstName);
        }

        public static IQueryable<User> SortTaskByNameLength(this IQueryable<User> query, SortDirection sortDirection)
        {

            switch (sortDirection)
            {
                case SortDirection.Asending:
                    query.Select(u => u.Tasks.OrderBy(t => t.Name.Length));
                    break;
                case SortDirection.Descending:
                    query.Select(u => u.Tasks.OrderByDescending(t => t.Name.Length));
                    break;
            }

            return query;
        }
    }
}
