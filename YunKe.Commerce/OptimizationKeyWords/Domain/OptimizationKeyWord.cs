using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.KeyWordRank.Domain;
using YunKe.Commerce.Projects.Domain;
using YunKe.Shared.Enums;

namespace YunKe.Commerce.OptimizationKeyWords.Domain
{
    public class OptimizationKeyWord : BaseEntity
    {
        [Required]
        public string KeyWord { get; set; }

        public decimal Price { get; set; }

        public PricingUnit PricingUnit { get; set; }

        public RankingStatus RankingStatus { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        [ForeignKey("Project")]
        [Required]
        public string ProjectId { get; set; }

        /// <summary>
        /// 系统计算价格
        /// </summary>
        /// <value>
        /// The system price model.
        /// </value>
        public KeyWordPrice SystemPriceModel { get; set; }

        /// <summary>
        /// 用户设置价格
        /// </summary>
        /// <value>
        /// The price model.
        /// </value>
        public KeyWordPrice PriceModel { get; set; }

        /// <summary>
        /// 原始排名
        /// </summary>
        /// <value>
        /// The system price model.
        /// </value>
        public SearchEngineRanking OriginalRanking { get; set; }

        public virtual ICollection<KeyWordRankHistory> RankHistory { get; set; }

        public OptimizationKeyWord()
        {
            RankHistory = new HashSet<KeyWordRankHistory>();
        }
    }
}
