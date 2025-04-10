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
        public ChatMessage ChatMessage { get; set; }

        public string MessageToFormat(ChatMessage chatMessage)
        {
            return $"{chatMessage.User}: {chatMessage.Message}";
        }

        public ChatMessageViewModel(ChatMessage chatMessage)
        {
            ChatMessage = chatMessage;
        }
    }
}
