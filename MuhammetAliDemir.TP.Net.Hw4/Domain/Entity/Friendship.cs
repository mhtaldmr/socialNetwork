using System.ComponentModel.DataAnnotations.Schema;

namespace MuhammetAliDemir.TP.Net.Hw4.Domain.Entity
{
    public class Friendship
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int SourceId { get; set; }
        [ForeignKey("SourceId")]
        public User Source { get; set; }

        public int TargetId { get; set; }
        [ForeignKey("TargetId")]
        public User Target { get; set; }
    }
}