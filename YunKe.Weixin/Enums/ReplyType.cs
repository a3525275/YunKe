using System.ComponentModel;

namespace YunKe.Weixin.Entity
{
    public enum ReplyType
    {
        [Description("关键字回复")]
        Keys = 2,
        [Description("无匹配回复")]
        NoMatch = 4,
        None = 0,
        [Description("关注时回复")]
        Subscribe = 1,
        Wheel = 8
    }
}