using TP.Net.Hw4.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP.Net.Hw4.Domain.Common
{
    public class MessageType
    {
        public int Id { get; set; }
        public int MessageTypeId { get; set; }
        public string MessageTypeName { get; set; }
    }
}
