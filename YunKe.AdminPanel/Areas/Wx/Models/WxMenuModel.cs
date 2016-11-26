using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YunKe.Weixin.Entity;

namespace YunKe.AdminPanel.Areas.Wx.Models
{
    public class WxMenuModel
    {
        [Required, MaxLength(50), DisplayName("菜单名称")]
        public string Name { get; set; }

        [MaxLength(50)]
        public string BindValue { get; set; }

        [DisplayName("绑定类型")]
        public BindType Bind { get; set; }

        public SelectListItem[] BindTypes { get; set; }

        [DisplayName("专题列表")]
        public SelectListItem[] Topics { get; set; }

        [DisplayName("选择关键字")]
        public SelectListItem[] Keywords { get; set; }

        [DisplayName("绑定类型")]
        public string BindType { get; set; }

        [DisplayName("父级菜单")]
        public string ParentId { get; set; }

        [DisplayName("链接")]
        public string Url { get; set; } = "http://";

        [DisplayName("选择专题")]
        public string BindTopic { get; set; }

        public string Id { get; set; }

        [DisplayName("创建时间")]
        public DateTime CreateDateTime { get; set; }

        [DisplayName("上级菜单")]
        public WxMenu ParentMenu { get; set; }

        public int Sequence { get; set; }
    }
}