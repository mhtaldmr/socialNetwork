using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw.Domain.Common;

namespace TP.Net.Hw.Domain.Entity
{
    public class UserMessage : BaseEntity
    {
        public string MessageBody { get; set; }

        public int MessageTypeId { get; set; }
        [ForeignKey("MessageTypeId")]
        public MessageType MessageType { get; set; }


        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public int ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }

    }
}
