using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YunKe.AdminPanelCore.Entity;
using YunKe.Shared.Enums;

namespace YunKe.Commerce.Members.Domain
{
    /// <summary>
    /// 实名认证信息
    /// </summary>
    /// <seealso cref="YunKe.AdminPanelCore.Entity.BaseEntity" />
    public class ValidationRecord : BaseEntity
    {
        [Required]
        [StringLength(128)]
        [ForeignKey("Member")]
        public string MemberId { get; set; }

        public virtual Member Member { get; set; }

        /// <summary>
        /// Gets or sets the type of the validation.
        /// </summary>
        /// <value>
        /// The type of the validation.
        /// </value>
        [DisplayName("认证类型")]
        public RealNameValidationType ValidationType { get; set; }

        /// <summary>
        /// Gets or sets the identity card image.
        /// </summary>
        /// <value>
        /// The identity card image.
        /// </value>
        [DisplayName("身份证正面扫描件")]
        public string IdentityCardImage { get; set; }

        /// <summary>
        /// Gets or sets the identity card image secondary.
        /// </summary>
        /// <value>
        /// The identity card image secondary.
        /// </value>
        [DisplayName("身份证背面扫描件")]
        public string IdentityCardImageSecondary { get; set; }

        public string Name { get; set; }

        [StringLength(64), DisplayName("统一社会信用代码")]
        public string BusinessCreditNumber { get; set; }

        [StringLength(64), DisplayName("营业执照注册号")]
        public string BusinessLicenceNumber { get; set; }

        [DisplayName("营业执照扫描件")]
        public string BusinessLicenceScanImage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is seoer cooperation agreement checked.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is seoer cooperation agreement checked; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("签署劳务合作协议是否验证")]
        public bool IsSeoerCooperationAgreementChecked { get; set; }

        [StringLength(128), DisplayName("法人")]
        public string CompanyOwner { get; set; }

        [StringLength(128), DisplayName("联系电话")]
        public string CompanyPhone { get; set; }

        [StringLength(128), DisplayName("行业")]
        public string Industry { get; set; }

        [DisplayName("认证时间")]
        public DateTime? CheckedDate { get; set; }

        [DisplayName("提交认证时间")]
        public DateTime? PostCheckingDate { get; set; }

        [DisplayName("是否认证通过")]
        public bool IsPass { get; set; }

        [StringLength(200), DisplayName("最后一次认证不通过说明")]
        public string LastStatusReason { get; set; }
    }
}