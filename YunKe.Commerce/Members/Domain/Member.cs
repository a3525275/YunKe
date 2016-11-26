using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Infrastructure.Utilities;
using YunKe.Shared.Enums;

namespace YunKe.Commerce.Members.Domain
{
    public class Member : BaseEntity
    {
        [StringLength(11)]
        public string Mobile { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        [StringLength(32)]
        public string NickName { get; set; }

        [StringLength(256)]
        public string Password { get; set; }

        [StringLength(1024)]
        public string PayPassword { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(32)]
        public string QQ { get; set; }

        public Gender Gender { get; set; }

        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Gets or sets the identity.
        /// </summary>
        /// <value>
        /// The identity.
        /// </value>
        [StringLength(20)]
        public string Identity { get; set; }

        public Address Address { get; set; }

        public UserType MemberType { get; set; }

        public UserStatus Status { get; set; }

        [StringLength(256)]
        public string OpenId { get; set; }

        public bool IsRealNameValidated { get; set; }

        public bool IsEmailValidated { get; set; }

        public bool IsMobilePhoneValidated { get; set; }

        public decimal Balance { get; set; }

        /// <summary>
        /// 邮箱激活代码
        /// </summary>
        /// <value>
        /// The email active code.
        /// </value>
        public string EmailActiveCode { get; set; }

        public virtual ICollection<PaymentProfile> PaymentProfiles { get; set; }

        public virtual ICollection<EducationHistory> EducationHistories { get; set; }

        public virtual ICollection<MemberAddress> MemberAddresses { get; set; }

        public virtual ICollection<ValidationRecord> ValidationRecords { get; set; }


        public Member()
        {
            PaymentProfiles = new HashSet<PaymentProfile>();
            EducationHistories = new HashSet<EducationHistory>();
            ValidationRecords = new HashSet<ValidationRecord>();
        }
    }
}
