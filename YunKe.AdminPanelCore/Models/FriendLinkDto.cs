using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.AdminPanelCore.Models
{
    public class FriendLinkDto
    {
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Text { get; set; }

        [Required]
        [StringLength(1024)]
        public string Link { get; set; }

        [StringLength(1024)]
        public string Image { get; set; }

        public int Sequence { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
