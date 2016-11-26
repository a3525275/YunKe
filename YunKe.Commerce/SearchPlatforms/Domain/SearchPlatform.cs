using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.KeyWordRank.Domain;

namespace YunKe.Commerce.SearchPlatforms.Domain
{
    public class SearchPlatform : BaseEntity
    {
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Icon { get; set; }

        public virtual ICollection<KeyWordRankHistory> KeyWordRankHistory { get; set; }

        public SearchPlatform()
        {
            KeyWordRankHistory = new HashSet<KeyWordRankHistory>();
        }
    }
}
