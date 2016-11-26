using YunKe.Infrastructure.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YunKe.AdminPanelCore.Entity
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            IsDeleted = false;
            CreateDateTime = DateTime.Now;
            Sequence = 0;
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        [DisplayName("创建日期")]
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 序号（越小越靠前）
        /// </summary>
        [DisplayName("序号")]
        public int Sequence { get; set; }

        [DisplayName("修改人"), StringLength(128)]
        public string ModifiedBy { get; set; }

        [DisplayName("修改时间")]
        public DateTime? ModifiedDate { get; set; }
    }
}
