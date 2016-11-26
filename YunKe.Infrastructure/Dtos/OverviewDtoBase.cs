using System;
using System.ComponentModel;

namespace YunKe.Infrastructure.Dtos
{
    public class OverviewDtoBase
    {
        [DisplayName("创建时间")]
        public DateTime CreateDateTime { get; set; }

        [DisplayName("序号")]
        public int Sequence { get; set; }

        public string Id { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
