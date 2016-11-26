using YunKe.Infrastructure.Data.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Service
{
    public static class IRepositoryExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repo"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<T> Query<T>(this IRepository<T> repo, Expression<Func<T, bool>> query = null)
            where T : class, new()
        {
            return repo.Query(query);
        }
    }
}
