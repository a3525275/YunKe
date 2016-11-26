using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Weixin.Models
{
    public class NewsReplyInfo : ReplyInfo
    {
        public NewsReplyInfo()
        {
            MessageType = Weixin.Entity.MessageType.List;
        }

        public IList<NewsMsgInfo> NewsMsg { get; set; }
    }
}
