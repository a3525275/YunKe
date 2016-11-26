using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using YunKe.AdminPanelCore.Entity;

namespace YunKe.Commerce.Articles.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="YunKe.AdminPanelCore.Entity.BaseEntity" />
    public class ArticleCategory : BaseEntity
    {
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Code { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [ScriptIgnore(ApplyToOverrides = true)]
        public virtual ICollection<Article> Articles { get; set; }

        public ArticleCategory()
        {
            Articles = new HashSet<Article>();
        }
    }
}