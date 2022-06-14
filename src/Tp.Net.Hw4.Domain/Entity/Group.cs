using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw4.Domain.Common;

namespace TP.Net.Hw4.Domain.Entity
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