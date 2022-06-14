using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw4.Domain.Common;

namespace TP.Net.Hw4.Domain.Entity
{
    public class UserPost : BaseEntity
    {
        public string PostBody { get; set; }
        public string PostTitle { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
