using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YunKe.AdminPanelCore.Entity;
using YunKe.Infrastructure.Utilities;

namespace YunKe.Commerce.Members.Domain
{
    public class MemberAddress : BaseEntity
    {
        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        [Required]
        [StringLength(128)]
        [ForeignKey("Member")]
        public string MemberId { get; set; }

        public virtual Member Member { get; set; }

        public Address Address { get; set; }

        public bool IsDefault { get; set; }

        public MemberAddress()
        {
            Address = new Address();
        }
    }
}