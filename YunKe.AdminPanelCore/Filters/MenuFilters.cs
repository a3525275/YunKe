using YunKe.Infrastructure.Data.Filters;
using YunKe.AdminPanelCore.Enum;

namespace YunKe.AdminPanelCore.Models.Filters
{
    /// <summary>
    /// 菜单搜索过滤器
    /// </summary>
    public class MenuFilters : BaseFilter
    {
        /// <summary>
        /// 排除的类型
        /// </summary>
        public MenuType? ExcludeType { get; set; }
    }
}
