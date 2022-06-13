using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw4.Domain.Common;

namespace TP.Net.Hw4.Domain.Entity
{
    public class UserMessageArchive : BaseEntity
    {
        public int MessageId { get; set; }
        public string MessageBody { get; set; }

        public int MessageTypeId { get; set; }
        [ForeignKey("MessageTypeId")]
        public MessageType MessageType { get; set; }
    }
}
