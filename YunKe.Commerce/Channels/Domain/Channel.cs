using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Agents.Domain;
using YunKe.Commerce.Members.Domain;
using YunKe.Infrastructure.Utilities;
using YunKe.Shared.Enums;

namespace YunKe.Commerce.Channels.Domain
{
    /// <summary>
    /// 渠道
    /// </summary>
    public class Channel : Member
    {
        public virtual ICollection<Agent> Agents { get; set; }

        public Channel()
        {
            Agents = new HashSet<Agent>();
        }
    }
}
