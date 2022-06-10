using TP.Net.Hw4.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP.Net.Hw4.Domain.Common
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

        [ForeignKey("MessageTypeId")]
        public GroupMessageArchive GroupMessageArchive { get; set; }

        public string MessageTypeName { get; set; }
    }
}
