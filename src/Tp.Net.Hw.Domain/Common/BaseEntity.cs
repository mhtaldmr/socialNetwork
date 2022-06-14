using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP.Net.Hw.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [Column(Order=0)]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
