using System.ComponentModel.DataAnnotations.Schema;
using TP.Net.Hw.Domain.Common;

namespace TP.Net.Hw.Domain.Entity
{
    public class UserPostComment : BaseEntity
    {
        public string CommentBody { get; set; }

        public int CommentTypeId { get; set; }
        [ForeignKey("CommentTypeId")]
        public CommentType CommentType { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserPostId { get; set; }
        [ForeignKey("UserPostId")]
        public UserPost UserPost { get; set; }
    }
}