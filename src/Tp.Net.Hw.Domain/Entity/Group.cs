using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw.Domain.Common;

namespace TP.Net.Hw.Domain.Entity
{
    public class Group : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public User Admin { get; set; }
    }
}