using System.ComponentModel.DataAnnotations;
using YunKe.Infrastructure.Commands;

namespace YunKe.Commerce.FriendLinks.Commands
{
    public class UpdateFriendLinkCommand : UpdateCommandBase
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
    }
}
