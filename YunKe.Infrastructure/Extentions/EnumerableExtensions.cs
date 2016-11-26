using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Extentions
{
    /// <summary>
    /// 扩展集合功能
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 将字符串加在一起
        /// </summary>
        /// <param name="source"></param>
        /// <param name="splitor">分隔符</param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> source, string splitor)
        {
            if (source == null) return string.Empty;

            return string.Join(splitor, source);
        }
        /// <summary>
        /// 将数据源映射成字符串数据源后加在一起
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="splitor">分隔符</param>
        /// <param name="selector">映射器</param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> source, string splitor, Func<T, string> selector)
        {
            if (source == null) return string.Empty;

            return source.Select(selector).Join(splitor);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="splitor"></param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> source, string splitor)
        {
            if (source == null) return string.Empty;

            return source.Select(x => x.ToString()).Join(splitor);
        }
        /// <summary>
        /// 为集合添加元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="add"></param>
        /// <returns></returns>
        public static IEnumerable<T> Plus<T>(this IEnumerable<T> source, T add)
        {
            foreach (var element in source)
            {
                yield return element;
            }
            yield return add;
        }
        /// <summary>
        /// 将元素添加到集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="add"></param>
        /// <returns></returns>
        public static IEnumerable<T> Plus<T>(this T source, IEnumerable<T> add)
        {
            yield return source;
            foreach (var element in add)
            {
                yield return element;
            }
        }

        /// <summary>
        /// 对source的每一个元素执行指定的动作action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null || action == null)
                return;

            foreach (var element in source)
            {
                action(element);
            }
        }

        /// <summary>
        /// 判断序列是否包含任何元素，如果序列为空，则返回False
        /// </summary>
        /// <typeparam name="T">序列类型</typeparam>
        /// <param name="source">序列</param>
        /// <returns></returns>
        public static bool AnyOne<T>(this IEnumerable<T> source)
        {
            return source != null ? source.Any() : false;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public static PagedResult<T> Paging<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0)
                throw new ArgumentException("Index of current page can not less than 0 !", "pageIndex");
            if (pageSize <= 1)
                throw new ArgumentException("Size of page can not less than 1 !", "pageSize");

            var pagedQuery = source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return new PagedResult<T>
            {
                rows = pagedQuery.ToList(),
                records = source.Count(),

                page = pageIndex,
                pagesize = pageSize
            };
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public static PagedResult<T2> Paging<T1, T2>(this IQueryable<T1> source, int pageIndex, int pageSize, Func<IEnumerable<T1>, IEnumerable<T2>> mappingFunc)
        {
            if (pageIndex <= 0)
                throw new ArgumentException("Index of current page can not less than 0 !", "pageIndex");
            if (pageSize <= 1)
                throw new ArgumentException("Size of page can not less than 1 !", "pageSize");

            var pagedQuery = source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return new PagedResult<T2>
            {
                rows = mappingFunc(pagedQuery.ToList()).ToList(),
                records = source.Count(),

                page = pageIndex,
                pagesize = pageSize
            };
        }


        /// <summary>
        /// Returns the index of the first occurrence in a sequence by using a specified IEqualityComparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="list">A sequence in which to locate a value.</param>
        /// <param name="value">The object to locate in the sequence</param>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <returns>
        /// The zero-based index of the first occurrence of value within the entire sequence, if found; otherwise, –1.
        /// </returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> list, TSource value, IEqualityComparer<TSource> comparer)
        {
            int index = 0;
            foreach (var item in list)
            {
                if (comparer.Equals(item, value))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public static async Task<PagedResult<T>> PagingAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0)
                throw new ArgumentException("Index of current page can not less than 0 !", "pageIndex");
            if (pageSize <= 1)
                throw new ArgumentException("Size of page can not less than 1 !", "pageSize");

            var pagedQuery = source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return new PagedResult<T>
            {
                rows = await pagedQuery.ToListAsync(),
                records = await source.CountAsync(),

                page = pageIndex,
                pagesize = pageSize
            };
        }
    }
}
