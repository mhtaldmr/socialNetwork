using System.ComponentModel.DataAnnotations.Schema;

namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Entity
{
    public class FriendshipRequest
    {
        public int Id { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int SourceId { get; set; }
        [ForeignKey("SourceId")]
        public User Source { get; set; }

        public int TargetId { get; set; }
        [ForeignKey("TargetId")]
        public User Target { get; set; }
    }
}