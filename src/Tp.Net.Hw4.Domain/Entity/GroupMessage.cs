using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw4.Domain.Common;

namespace TP.Net.Hw4.Domain.Entity
{
    public class GroupMessage : BaseEntity
    {
        public string MessageBody { get; set; }

        public int MessageTypeId { get; set; }
        [ForeignKey("MessageTypeId")]
        public MessageType MessageType { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
    }
}
