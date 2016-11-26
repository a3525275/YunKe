using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;

namespace YunKe.Commerce.Indutries.Domain
{
    public class IndustryInfo : BaseEntity
    {
        [StringLength(64)]
        public string Name { get; set; }

        [StringLength(64)]
        public string Code { get; set; }

        [StringLength(64)]
        public string Icon { get; set; }
    }
}
