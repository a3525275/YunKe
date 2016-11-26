
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YunKe.Shared.Enums;
using YunKe.AdminPanelCore.Entity;
using System;

namespace YunKe.Commerce.Members.Domain
{
    public class PaymentProfile : BaseEntity
    {
        [Required]
        [StringLength(128)]
        [ForeignKey("Member")]
        public string MemberId { get; set; }

        public virtual Member Member { get; set; }

        [StringLength(64), DisplayName("银行名称")]
        public string BankName { get; set; }

        [StringLength(64), DisplayName("银行卡号")]
        public string CardNumber { get; set; }

        [StringLength(64), DisplayName("开户省")]
        public string Province { get; set; }

        [StringLength(64), DisplayName("开户城市")]
        public string City { get; set; }

        [StringLength(64), DisplayName("开户地区")]
        public string State { get; set; }

        [StringLength(256), DisplayName("开户行名称")]
        public string SubBankName { get; set; }

        [DisplayName("支付测试通过")]
        public bool IsPayTestPass { get; set; }

        [DisplayName("支付测试通过时间")]
        public DateTime PassDate { get; set; }

        public bool IsDefault { get; set; }
    }
}