using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw.Domain.Common;

namespace TP.Net.Hw.Domain.Entity
{
    public class GroupMessageArchive : BaseEntity
    {
        public int MessageId { get; set; }
        public string MessageBody { get; set; }
     
        public int MessageTypeId { get; set; }
        [ForeignKey("MessageTypeId")]
        public MessageType MessageType { get; set; }
    }
}