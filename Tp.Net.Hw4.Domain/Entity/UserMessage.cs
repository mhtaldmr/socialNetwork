using System.ComponentModel.DataAnnotations.Schema;

namespace TP.Net.Hw4.Domain.Entity
{
    public class UserMessage
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }
        public int MessageTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public int ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }

    }
}
