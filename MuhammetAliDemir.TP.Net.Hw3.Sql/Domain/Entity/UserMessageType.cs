using System.ComponentModel.DataAnnotations.Schema;

namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Entity
{
    public class UserMessageType
    {
        public int Id { get; set; }

        public int MessageTypeId { get; set; }

        [ForeignKey("MessageTypeId")]
        public UserMessage UserMessage { get; set; }

        [ForeignKey("MessageTypeId")]
        public UserMessageArchive UserMessageArchive{ get; set; }

        public string MessageTypeName { get; set; }
    }
}
