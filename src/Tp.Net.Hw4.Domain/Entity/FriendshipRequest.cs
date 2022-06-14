using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw4.Domain.Common;

namespace TP.Net.Hw4.Domain.Entity
{
    public class FriendshipRequest : BaseEntity
    {
        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public int ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }
    }
}