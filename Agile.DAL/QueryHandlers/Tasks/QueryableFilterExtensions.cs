using Agile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Infrastructure.QueryHandlers.Tasks
{
    public static class QueryableFilterExtensions
    {
        public static IQueryable<Task> FilterByYear(this IQueryable<Task> query, int year) 
            => query.Where(task => task.FinishedAt.Year == year);

        public static IQueryable<Task> FilterByNameLessLength(this IQueryable<Task> query, int length)
            => query.Where(task => task.Name.Length < length);

    }
}
