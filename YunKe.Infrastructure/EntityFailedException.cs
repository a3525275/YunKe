using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure
{
    [Serializable]
    public class EntityFailedException : Exception
    {
        public string FieldName { get; set; }
        public EntityFailedException(string fieldName, string msg)
            : base(msg)
        {
            this.FieldName = fieldName;
        }
    }
}
