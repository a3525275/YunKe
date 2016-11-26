using System.Collections.Generic;

namespace YunKe.Infrastructure.Data.Filters
{
    public interface IBaseFilter
    {
        bool KeyWordHandled { get; set; }
        string keywords { get; set; }
        string KeywordsField { get; set; }
        string nodeId { get; set; }
        int page { get; set; }
        string ParentFieldName { get; set; }
        int rows { get; set; }
        bool TreeData { get; set; }

        List<KeyValuePair<string, object>> AdditionalQueries { get; set; }
    }
}