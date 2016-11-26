using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Channels.Domain;
using YunKe.Commerce.Customers.Domain;
using YunKe.Commerce.Members.Domain;
using YunKe.Infrastructure.Utilities;
using YunKe.Shared.Enums;

namespace YunKe.Commerce.Agents.Domain
{
    public class Agent : Member
    {
        [StringLength(128)]
        [Required]
        [ForeignKey("Channel")]
        public string ChannelId { get; set; }

        [ForeignKey("ChannelId")]
        public virtual Channel Channel { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public Agent()
        {
            Customers = new HashSet<Customer>();
        }
    }
}
