using System.ComponentModel.DataAnnotations.Schema;

namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Entity
{
    public class FriendshipApproval
    {
        public int Id { get; set; }
        public int RequestStatusId { get; set; }
     
        public int FriendshipRequestId { get; set; }

        [ForeignKey("FriendshipRequestId")]
        public FriendshipRequest FriendshipRequest { get; set; }

    }
}