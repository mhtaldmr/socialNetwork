using TP.Net.Hw.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP.Net.Hw.Domain.Common
{
    public class CommentType
    {
        public int Id { get; set; }
        public int CommentTypeId { get; set; }
        public string CommentTypeName { get; set; }
    }
}
