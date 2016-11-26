using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Infrastructure.Dtos;

namespace YunKe.Commerce.Customers.Dtos
{
   public  class CustomersOverviewDto : OverviewDtoBase
    {
        [DisplayName("公司名称"), Required]
        public string CompanyName { get; set; }
        [DisplayName("客户名称"), Required]
        public string Name { get; set; }
        [DisplayName("联系人"), Required]
        public string NickName { get; set; }
        [DisplayName("手机"), Required]
        public string Mobile { get; set; }
        [DisplayName("邮箱"), Required]
        public string Email { get; set; }

        public string WebSite { get; set; }

        public int VipLevel { get; set; }

        public string AgentId { get; set; }
    }
}
