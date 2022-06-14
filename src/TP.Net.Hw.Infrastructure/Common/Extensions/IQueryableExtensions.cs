using System.Linq.Expressions;
using TP.Net.Hw.Application.Dtos.Requests;
using TP.Net.Hw.Application.Interfaces.Models;
using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.Infrastructure.Common.Extensions
{
    public static class IQueryableExtensions
    {
        //Extension for Fintering The User Messages
        public static IQueryable<UserMessage> ApplyFiltering(this IQueryable<UserMessage> query, UserMessageQueryDto queryObj)
        {
            if (!string.IsNullOrWhiteSpace(queryObj.MessageBody))
                return query.Where(m => m.MessageBody.Contains(queryObj.MessageBody));

            if (queryObj.CreatedAt.HasValue)
                return query.Where(m => m.CreatedAt > queryObj.CreatedAt.Value);

            return query;
        }

        //Extension for Paging as a GENERIC input Type
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = (byte)query.Count();

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
    
        }

        //Extension for Ordering as a GENERIC input Type
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> messageColumns)
        {
            if (string.IsNullOrWhiteSpace(queryObj.SortBy) || !messageColumns.ContainsKey(queryObj.SortBy))
                return query;

            if (queryObj.IsSortAscending)
                return query.OrderBy(messageColumns[queryObj.SortBy]);
            else
                return query.OrderByDescending(messageColumns[queryObj.SortBy]);

        }

    }
}
