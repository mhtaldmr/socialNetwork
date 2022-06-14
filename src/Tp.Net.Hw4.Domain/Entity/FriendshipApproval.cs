using System.ComponentModel.DataAnnotations.Schema;

namespace TP.Net.Hw4.Domain.Entity
{
    public class FriendshipApproval
    {
        public int Id { get; set; }
        public bool IsAccepted { get; set; }
     
        public int FriendshipRequestId { get; set; }

        [ForeignKey("FriendshipRequestId")]
        public FriendshipRequest FriendshipRequest { get; set; }

    }
}