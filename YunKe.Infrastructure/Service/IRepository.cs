using YunKe.Infrastructure.Data.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Service
{
    public interface IRepository<T> where T : class, new()
    {
        bool Insert(T entity);

        bool Update(T entity, Func<T, object[]> primaryKey);

        bool UpdateBatch(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> setter);

        bool Delete(T obj);

        bool DeleteBatch(Expression<Func<T, bool>> predicate);

        IQueryable<T> Query(Expression<Func<T, bool>> predicate);

        PagedResult<T> GetDataForListPager(IBaseFilter filters);

        PagedResult<TDto> GetPagedData<TDto>(IBaseFilter filters, Func<IEnumerable<T>, IEnumerable<TDto>> listMapper);

        T Get(Expression<Func<T, bool>> predicate);
    }
}
