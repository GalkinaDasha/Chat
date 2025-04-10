using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Chat.Domain.Models;
using Chat.WPF.Services;
using Chat.WPF.ViewModels;

namespace Chat.WPF.Commands
{
    public class SendChatMessageCommand : ICommand
    {
        private readonly ChatViewModel _viewModel;
        private readonly SignalRChatService _chatService;

        public SendChatMessageCommand(ChatViewModel viewModel, SignalRChatService chatService)
        {
            _viewModel = viewModel;
            _chatService = chatService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                // отправляем сообщение
                await _chatService.SendMessage(new ChatMessage()
                {
                    User = _viewModel.User,
                    Message = _viewModel.Message,
                });

                _viewModel.ErrorMessage = string.Empty;
            }
            catch (Exception)
            {
                // обработка ошибки отправки
                _viewModel.ErrorMessage = "Unable to send message.";
            }
        }
    }
}
