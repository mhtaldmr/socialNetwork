using TP.Net.Hw4.Application.Interfaces.Models;

namespace TP.Net.Hw4.Infrastructure.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, IQueryObject queryObj)
        {



            return query;
        }

        public static IQueryable<T> ApplySearching<T>(this IQueryable<T> query, IQueryObject queryObj)
        {



            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {



            return query;
        }

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj)
        {



            return query;
        }
    }
}
