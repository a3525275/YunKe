using System;

namespace YunKe.Infrastructure.Commands
{
    public class UpdateCommandBase : ICommand
    {
        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
