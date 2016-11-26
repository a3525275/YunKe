using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Utilities
{
    public class Address
    {
        [StringLength(128)]
        public string Country { get; set; }

        [StringLength(128)]
        public string City { get; set; }

        [StringLength(128)]
        public string Province { get; set; }

        [StringLength(512)]
        public string DetailAddress { get; set; }

        [StringLength(128)]
        public string Zip { get; set; }


    }
}
