using System.ComponentModel;

namespace YunKe.Weixin.Entity
{
    public enum MessageType
    {
        [Description("多图文")]
        List = 4,

        [Description("单图文")]
        News = 2,

        [Description("文本")]
        Text = 1
    }
}