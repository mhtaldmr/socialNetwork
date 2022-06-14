using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Net.Hw4.Application.Dtos.Responses
{
    public class UserMessagesResponse
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }
        public string MessageType { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
