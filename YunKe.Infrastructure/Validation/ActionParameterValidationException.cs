using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Validation
{
    public class ActionParameterValidationException : Exception
    {
        public string ParameterName { get; private set; }

        public ActionParameterValidationException(string parameter, string msg)
            : base(msg)
        {
            this.ParameterName = parameter;
        }

    }
}
