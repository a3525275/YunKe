using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Members.Domain;
using YunKe.Commerce.OptimizatorTeams.Domain;
using YunKe.Commerce.Projects.Domain;
using YunKe.Commerce.Questions.Domain;
using YunKe.Commerce.Tenders.Domain;

namespace YunKe.Commerce.Optimizators.Domain
{
    public class Optimizator : Member
    {
        [ForeignKey("Team")]
        public virtual string TeamId { get; set; }

        public decimal CompletingRate { get; set; }

        /// <summary>
        /// 好评率， 1，2，3，4，5，
        /// </summary>
        /// <value>
        /// The praise.
        /// </value>
        public int Praise { get; set; }

        public int Level { get; set; }

        public virtual OptimizatorTeam Team { get; set; }

        public virtual ICollection<OptimizationTask> Tasks { get; set; }

        public virtual ICollection<Tender> Tenderings { get; set; }

        public Optimizator()
        {
            Tenderings = new HashSet<Tender>();
            Tasks = new HashSet<OptimizationTask>();
        }
    }
}
