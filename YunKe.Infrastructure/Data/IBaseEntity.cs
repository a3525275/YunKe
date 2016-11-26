using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Data
{
    public interface IBaseEntity
    {
        DateTime CreateDateTime { get; set; }

        string Id { get; set; }

        bool IsDeleted { get; set; }

        int Sequence { get; set; }

        string ModifiedBy { get; set; }

        DateTime? ModifiedDate { get; set; }
    }
}
