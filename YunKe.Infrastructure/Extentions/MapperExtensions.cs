using AutoMapper;
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
    public static class MapperExtensions
    {
        public static PagedResult<TDestionation> MapPageList<TDestionation, TSource>(this IMapper mapper, PagedResult<TSource> source)
        {
            var newResult = new PagedResult<TDestionation>()
            {
                page = source.page,
                pagesize = source.pagesize,
                records = source.records,
                rows = source.rows.Select(x => mapper.Map<TSource, TDestionation>(x)).ToList(),
            };

            return newResult;
        }
    }
}
