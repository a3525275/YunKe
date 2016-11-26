using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;

namespace YunKe.Commerce.Activities.Domain
{
    public class Activity : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        public string SenderId { get; set; }

        public string Link { get; set; }
    }
}
