using System.ComponentModel;

namespace YunKe.Weixin.Entity
{
    public enum BindType
    {
        /// <summary>
        /// 不绑定
        /// </summary>
        [Description("不绑定")]
        None,
        /// <summary>
        /// 关键字
        /// </summary>
        [Description("关键字")]
        Key,

        /// <summary>
        /// 主题
        /// </summary>
        [Description("主题")]
        Topic,

        /// <summary>
        /// 链接
        /// </summary>
        [Description("链接")]
        Url,

        /// <summary>
        /// 首页
        /// </summary>
        [Description("首页")]
        HomePage,
    }
}