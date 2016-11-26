using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Customers.Domain;
using YunKe.Commerce.OptimizationKeyWords.Domain;
using YunKe.Commerce.Optimizators.Domain;
using YunKe.Commerce.Questions.Domain;
using YunKe.Commerce.Tenders.Domain;
using YunKe.Infrastructure.Utilities;
using YunKe.Shared.Enums;

namespace YunKe.Commerce.Projects.Domain
{
    public class Project : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Customer")]
        [StringLength(128)]
        public string CustomerId { get; set; }

        [ForeignKey("Optimizator")]
        [StringLength(128)]
        public string OptimizatorId { get; set; }

        [Required]
        [StringLength(128)]
        public string Domain { get; set; }

        public SiteSeoInfo SeoInfo { get; set; }

        public Address Address { get; set; }

        public RankingStatus RankingStatus { get; set; }

        [StringLength(128)]
        public string Industry { get; set; }

        /// <summary>
        /// Gets or sets the pricing unit.
        /// </summary>
        /// <value>
        /// The pricing unit.
        /// </value>
        public PricingUnit PricingUnit { get; set; }

        public int Status { get; set; }

        public DateTime? FinishDate { get; set; }

        [StringLength(128)]
        public string CancleReason { get; set; }

        public int Praise { get; set; }

        public int AllowTendingAmount { get; set; } = 0;

        public SearchEngineType SearchEngine { get; set; }

        /// <summary>
        /// 结束投标时间
        /// </summary>
        /// <value>
        /// The end teanding date.
        /// </value>
        public DateTime? EndTendingDate { get; set; }

        /// <summary>
        /// 开始投标时间
        /// </summary>
        /// <value>
        /// The start tending date.
        /// </value>
        public DateTime StartTendingDate { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        [StringLength(128)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public virtual Customer Customer { get; set; }

        public virtual Optimizator Optimizator { get; set; }

        /// <summary>
        /// 投标列表
        /// </summary>
        /// <value>
        /// The tenderers.
        /// </value>
        public virtual ICollection<Tender> Tenderers { get; set; }

        public virtual ICollection<OptimizationKeyWord> OptimizationKeyWords { get; set; }

        public Project()
        {
            Tenderers = new HashSet<Tender>();
            OptimizationKeyWords = new HashSet<OptimizationKeyWord>();
        }
    }
}
