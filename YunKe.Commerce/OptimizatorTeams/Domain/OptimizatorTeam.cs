using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Optimizators.Domain;

namespace YunKe.Commerce.OptimizatorTeams.Domain
{
    public class OptimizatorTeam : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("TeamOwner")]
        public string TeamOwnerId { get; set; }

        public virtual Optimizator TeamOwner { get; set; }

        public virtual ICollection<Optimizator> Members { get; set; }
    }
}
