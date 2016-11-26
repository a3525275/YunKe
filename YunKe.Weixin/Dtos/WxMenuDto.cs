using YunKe.Weixin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YunKe.Weixin.Dtos
{
    public class WxMenuDto
    {
        public BindType Bind { get; set; }

        public BindType BindType
        {
            get
            {
                return this.Bind;
            }
        }

        public virtual string BindTypeName
        {
            get
            {
                switch (this.BindType)
                {
                    case BindType.Key:
                        return "关键字";

                    case BindType.Topic:
                        return "专题";
                    case BindType.HomePage:
                        return "首页";
                    case BindType.Url:
                        return "自定义链接";
                }
                return string.Empty;
            }
        }

        public IList<WxMenuDto> Chilren { get; set; }

        public MenuClient Client { get; set; }

        public string Content { get; set; }

        public int Sequence { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string ParentId { get; set; }

        public string ReplyId { get; set; }

        public string Type { get; set; }

        public virtual string Url
        {
            get
            {
                string host = System.Web.HttpContext.Current.Request.Url.Host;
                string str2 = (this.Client == MenuClient.Weixin) ? "wx" : "home";
                switch (this.BindType)
                {
                    case BindType.Key:
                        return this.ReplyId.ToString();
                    case BindType.Topic:
                        return string.Format("http://{0}/{2}/topic.aspx?TopicId={1}", host, this.Content, str2);

                    case BindType.HomePage:
                        return string.Format("http://{0}/{1}", host, str2);
                    case BindType.Url:
                        return this.Content;
                }
                return string.Empty;
            }
        }

        public bool isLeaf
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ParentId);
            }
        }

        public bool expanded { get; set; } = false;

        public DateTime CreateDateTime { get; set; }
    }
}
