using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;

namespace YunKe.Weixin.Entity
{
    /// <summary>
    /// 微信自定义菜单
    /// </summary>
    public class WxMenu : BaseEntity
    {
        [DisplayName("菜单名称"), Required, MaxLength(50)]
        public string Name { get; set; }

        [DisplayName("类型"), MaxLength(50)]
        public string Type { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        [DisplayName("父级Id"), StringLength(128)]
        public string ParentId { get; set; }

        /// <summary>
        /// 关联的自定义回复
        /// </summary>
        [DisplayName("关联的自定义回复"), StringLength(128)]
        public string ReplyId { get; set; }

        /// <summary>
        /// 绑定类型
        /// </summary>
        [DisplayName("绑定类型")]
        public BindType Bind { get; set; }

        /// <summary>
        /// 绑定类型
        /// </summary>
        [DisplayName("绑定类型")]
        public virtual string BindTypeName
        {
            get
            {
                switch (this.Bind)
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

        /// <summary>
        /// 绑定内容
        /// </summary>
        [DisplayName("绑定内容"), MaxLength(300)]
        public string Content { get; set; }

        public MenuClient Client { get; set; }

        public WxMenu()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
