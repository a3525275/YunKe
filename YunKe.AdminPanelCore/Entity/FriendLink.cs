﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.AdminPanelCore.Entity
{
    public class FriendLink : BaseEntity
    {
        [StringLength(128)]
        public string Text { get; set; }

        [StringLength(1024)]
        public string Link { get; set; }

        [StringLength(1024)]
        public string Image { get; set; }
    }
}
