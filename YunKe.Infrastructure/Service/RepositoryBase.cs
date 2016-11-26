using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YunKe.Infrastructure.Data.Filters;
using YunKe.Infrastructure.Extentions;
using YunKe.Infrastructure.Data;
using System.Data.Entity.Infrastructure;

namespace YunKe.Infrastructure.Service
{
    public class RepositoryBase<T> : IRepository<T>
        where T : class, IBaseEntity, new()
    {
        protected IUnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(T obj)
        {
            var db = _unitOfWork.Context;
            var tbl = db.Set<T>();
            if (!tbl.Local.Contains(obj))
            {
                db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            }
            else
            {
                db.Set<T>().Remove(obj);
            }

            int ret = db.SaveChanges();

            return ret > 0;
        }

        public bool DeleteBatch(Expression<Func<T, bool>> predicate)
        {
            var db = _unitOfWork.Context;
            var tbl = db.Set<T>();
            IQueryable<T> query = tbl;
            if (predicate != null)
                query = query.Where(predicate);
            var objs = query.AsEnumerable();

            foreach (var entity in objs)
                tbl.Remove(entity);

            int ret = db.SaveChanges();

            return ret > 0;
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            var db = _unitOfWork.Context;
            IQueryable<T> query = db.Set<T>();
            if (predicate != null)
                query = query.Where(predicate);
            return query.FirstOrDefault();
        }

        public PagedResult<T> GetDataForListPager(IBaseFilter filters)
        {
            var pagedData = innerQuery(filters);
            var data = pagedData.Paging(filters.page, filters.rows);
            return data;
        }

        public PagedResult<TDto> GetPagedData<TDto>(IBaseFilter filters, Func<IEnumerable<T>, IEnumerable<TDto>> listMapper)
        {
            IQueryable<T> pagedData = innerQuery(filters);

            var data = pagedData.Paging(filters.page, filters.rows, p => listMapper(p));

            return data;
        }

        private IQueryable<T> innerQuery(IBaseFilter filters)
        {
            var dbSet = _unitOfWork.Context.Set<T>();
            var query = dbSet.AsQueryable();

            if (filters.keywords.IsNotBlank())
            {
                query = query.Where(string.Format("{0}.Contains(@0)", filters.KeywordsField), filters.keywords);
            }

            if (filters.AdditionalQueries != null && filters.AdditionalQueries.Count > 0)
            {
                foreach (var item in filters.AdditionalQueries)
                {
                    query = query.Where(item.Key, item.Value);
                }
            }

            if (filters.TreeData)
            {
                query = query.Where(string.Format("{0} == (@0)", filters.ParentFieldName), filters.nodeId);
            }

            query = query.OrderBy(p => p.Sequence).ThenByDescending(x => x.CreateDateTime);

            var data = query
                .Select(p => p);
            return data;
        }

        public virtual bool Insert(T obj)
        {
            var db = _unitOfWork.Context;
            var tbl = db.Set<T>();
            obj = tbl.Add(obj);

            try
            {
                if (string.IsNullOrWhiteSpace(obj.Id))
                {
                    obj.Id = Guid.NewGuid().ToString();
                }

                int ret = db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            var db = _unitOfWork.Context;
            IQueryable<T> query = db.Set<T>();
            if (predicate != null)
                query = query.Where(predicate);
            //if (orderby != null)
            //    query = orderby(query);
            //if (pageIndex >= 0 && pageSize > 0)
            //{
            //    totalRecords = query.Count();
            //    query = query.Skip(pageIndex * pageSize).Take(pageSize);
            //}

            return query;
        }

        public virtual int SaveChanges()
        {
            var db = _unitOfWork.Context;
            return db.SaveChanges();
        }

        public bool Update(T obj, Func<T, object[]> getKeys)
        {
            var db = _unitOfWork.Context;
            var entry = db.Entry(obj);

            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                var tbl = db.Set<T>();
                var keys = getKeys != null ? getKeys(obj) : new object[] { obj.Id };
                var currentEntry = tbl.Find(keys);
                if (currentEntry != null)
                {
                    var attachedEntry = db.Entry(currentEntry);
                    attachedEntry.CurrentValues.SetValues(obj);
                    attachedEntry.State = EntityState.Modified;
                }
                else
                {
                    tbl.Attach(obj);
                    entry.State = EntityState.Modified;
                }
            }

            int ret = db.SaveChanges();

            return true;
        }

        public bool UpdateBatch(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> setter)
        {
            var db = _unitOfWork.Context;
            IQueryable<T> query = db.Set<T>();
            if (predicate != null)
                query = query.Where(predicate);
            var objs = query.AsEnumerable();

            var func = setter.Compile();
            foreach (var obj in objs)
            {
                func(obj);
            }

            int totals = db.SaveChanges();

            return true;
        }

    }
}
