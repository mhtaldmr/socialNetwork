using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw4.Domain.Common;

namespace TP.Net.Hw4.Domain.Entity
{
    public class Friendship : BaseEntity
    {
        public bool IsActive { get; set; }

        public int SourceId { get; set; }
        [ForeignKey("SourceId")]
        public User Source { get; set; }

        public int TargetId { get; set; }
        [ForeignKey("TargetId")]
        public User Target { get; set; }
    }
}