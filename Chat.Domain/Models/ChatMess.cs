using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.Models
{
    public class ChatMessage
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}