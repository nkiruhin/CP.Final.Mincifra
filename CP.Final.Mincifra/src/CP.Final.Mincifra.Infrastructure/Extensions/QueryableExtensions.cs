using System;
using System.Linq;
using System.Linq.Expressions;

namespace CP.Final.Mincifra.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Разбиение на страницы
        /// </summary>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return query.Skip(skipCount).Take(maxResultCount);
        }

        /// <summary>
        /// Фильтрация по условию
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <param name="condition">Выражение</param>
        /// <param name="predicate">Предикат</param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }
    }
}
