using System;

namespace YunKe.Weixin.Dtos
{
    public class WxSiteMenuDto
    {
        public string Id { get; set; }

        public string Icon { get; set; }

        public string Link { get; set; }

        public string Text { get; set; }

        public string WxAccountId { get; set; }

        public DateTime CreateDateTime { get; set; }

        public int Sequence { get; set; }
    }
}
