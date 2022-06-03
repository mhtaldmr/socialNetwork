using MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Common
{
    public class RequestStatusType
    {
        public int Id { get; set; }
        public int RequestStatusId { get; set; }

        [ForeignKey("RequestStatusId")]
        public FriendshipApproval FriendshipApproval { get; set; }

        public string RequestStatusName { get; set; }
    }
}
