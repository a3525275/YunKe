using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.OptimizationKeyWords.Domain;
using YunKe.Commerce.SearchPlatforms.Domain;

namespace YunKe.Commerce.KeyWordRank.Domain
{
    public class KeyWordRankHistory : BaseEntity
    {
        public DateTime ComputeDate { get; set; }

        public int Page { get; set; }

        public int LastDayPage { get; set; }

        public decimal UpDownRate { get; set; }

        [Required]
        public string SearchEngineId { get; set; }

        public virtual SearchPlatform SearchEngine { get; set; }

        public string SearchEngineName { get; set; }

        public SearchEngineRanking Ranking { get; set; }

        [Required]
        [ForeignKey("OptimizationKeyWord")]
        public string OptimizationKeyWordId { get; set; }

        public virtual OptimizationKeyWord OptimizationKeyWord { get; set; }
    }
}
