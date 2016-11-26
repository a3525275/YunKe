using System.Collections.Generic;
using YunKe.Infrastructure.Queries;

namespace YunKe.Infrastructure.Data.Filters
{
    /// <summary>
    /// 基本过滤器
    /// </summary>
    public class BaseFilter : IBaseFilter
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 每页显示的数据量
        /// </summary>
        public int rows { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string keywords { get; set; }

        /// <summary>
        /// 获取或设置搜索 Keyword 的字段名。默认为 Name。
        /// </summary>
        public string KeywordsField { get; set; }

        /// <summary>
        /// 获取或设置搜索 parent id 的值。
        /// </summary>
        public string nodeId { get; set; }
        /// <summary>
        /// 
        /// 获取或设置搜索 parent 的字段名。默认为 ParentId。
        /// </summary>
        public string ParentFieldName { get; set; }

        public bool TreeData { get; set; }

        public bool KeyWordHandled { get; set; } = false;

        public List<KeyValuePair<string, object>> AdditionalQueries { get; set; }

        public BaseFilter()
        {
            KeywordsField = "Name";
            ParentFieldName = "ParentId";
            page = 1;
            rows = 20;
            AdditionalQueries = new List<KeyValuePair<string, object>>();
        }
    }
}
