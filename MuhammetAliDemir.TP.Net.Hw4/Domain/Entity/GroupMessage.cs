using System.ComponentModel.DataAnnotations.Schema;

namespace MuhammetAliDemir.TP.Net.Hw4.Domain.Entity
{
    public class GroupMessage
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }
        public int MessageTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
    }
}
