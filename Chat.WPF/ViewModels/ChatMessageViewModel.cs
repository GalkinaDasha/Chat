using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Chat.Domain.Models;

namespace Chat.WPF.ViewModels
{
    public class ChatMessageViewModel
    {
        public string Message { get; }
        public string User { get; }

        public ChatMessageViewModel(ChatMessage message)
        {
            Message = message.Message; 
            User = message.User; 
        }
    }
}
