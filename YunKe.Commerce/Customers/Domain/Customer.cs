using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Agents.Domain;
using YunKe.Commerce.Members.Domain;
using YunKe.Commerce.Projects.Domain;

namespace YunKe.Commerce.Customers.Domain
{
    public class Customer : Member
    {
        public virtual ICollection<Project> Projects { get; set; }

        [StringLength(256)]
        public string CompanyName { get; set; }

        [StringLength(256)]
        public string WebSite { get; set; }

        public int VipLevel { get; set; }

        [ForeignKey("Agent")]
        public string AgentId { get; set; }

        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }

        public Customer()
        {
            Projects = new HashSet<Project>();
        }
    }
}
