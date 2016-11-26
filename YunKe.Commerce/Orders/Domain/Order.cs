using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Projects.Domain;

namespace YunKe.Commerce.Orders.Domain
{
    public class Order : BaseEntity
    {
        public string ProjectId { get; set; }

        public decimal TotalPrice { get; set; }

        public string OrderNumber { get; set; }

        public string PaymentProvider { get; set; }

        public int Status { get; set; }
    }
}
