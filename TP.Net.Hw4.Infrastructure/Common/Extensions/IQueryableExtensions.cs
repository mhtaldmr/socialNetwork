using System.Linq.Expressions;
using System.Text.Json;
using TP.Net.Hw4.Application.Dtos.Requests;
using TP.Net.Hw4.Application.Dtos.Responses;
using TP.Net.Hw4.Application.Interfaces.Models;
using TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.Infrastructure.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<UserMessage> ApplyFiltering(this IQueryable<UserMessage> query, UserMessageQueryDto queryObj)
        {
            if (!string.IsNullOrWhiteSpace(queryObj.MessageBody))
                return query.Where(m => m.MessageBody.Contains(queryObj.MessageBody));

            if (queryObj.CreatedAt.HasValue)
                return query.Where(m => m.CreatedAt > queryObj.CreatedAt.Value);

            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 5;

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
    
        }

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
