using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hishop.Weixin.MP.Domain;
using static Hishop.Weixin.MP.Domain.TemplateMessage;

namespace YunKe.Weixin.Models
{
    public class SendNotificationModel
    {
        public string OpenIdSendTo { get; set; }

        public string Message { get; set; }
        public string AccessToken { get; set; }
        public string Url { get; set; }
        public IEnumerable<MessagePart> Data { get; set; }
        public string TemplateId { get; set; }
        public string TopColor { get; set; }
    }
}
