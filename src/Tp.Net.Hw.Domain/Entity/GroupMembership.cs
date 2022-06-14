using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw.Domain.Common;

namespace TP.Net.Hw.Domain.Entity
{
    public class GroupMembership : BaseEntity
    {
        public bool IsActive { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
    }
}