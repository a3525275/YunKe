using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Weixin.Models
{
    public class PublishWxMenuResponse
    {
        private readonly StringBuilder _sb;

        public Exception Error { get; set; }

        public bool Succee { get; set; }

        public PublishWxMenuResponse()
        {
            _sb = new StringBuilder();
        }

        public PublishWxMenuResponse AddMessage(string msg)
        {
            _sb.AppendLine(msg);
            return this;
        }

        public PublishWxMenuResponse SetSuccess(bool success)
        {
            this.Succee = success;
            return this;
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
