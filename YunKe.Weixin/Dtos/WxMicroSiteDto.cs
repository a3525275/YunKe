using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Weixin.Dtos
{
    public class WxMicroSiteDto
    {
        public string SiteName { get; set; }

        public string[] TopImages { get; set; }

        public List<WxSiteMenuDto> Menus { get; set; }
    }
}
