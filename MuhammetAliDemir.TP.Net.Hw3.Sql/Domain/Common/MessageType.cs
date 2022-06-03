using MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Common
{
    public class MessageType
    {
        public int Id { get; set; }

        public int MessageTypeId { get; set; }

        [ForeignKey("MessageTypeId")]
        public UserMessage UserMessage { get; set; }

        [ForeignKey("MessageTypeId")]
        public UserMessageArchive UserMessageArchive { get; set; }

        [ForeignKey("MessageTypeId")]
        public GroupMessage GroupMessage { get; set; }

        public string MessageTypeName { get; set; }
    }
}
