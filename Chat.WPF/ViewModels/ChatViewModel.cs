using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Chat.Domain.Models;
using Chat.WPF.Commands;
using Chat.WPF.Services;

namespace Chat.WPF.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private string _user;
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        private bool _isConnected;
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }

        public ObservableCollection<ChatMessageViewModel> Messages { get; }

        public ICommand SendChatMessageCommand { get; }

        private readonly SynchronizationContext _syncContext;

        public ChatViewModel(SignalRChatService chatService)
        {
            _syncContext = SynchronizationContext.Current; // Сохраняем текущий контекст синхронизации

            SendChatMessageCommand = new SendChatMessageCommand(this, chatService);

            Messages = new ObservableCollection<ChatMessageViewModel>();

            chatService.MessageReceived += ChatService_MessageReceived;
        }

        // отдельно соединение к хабу
        public static ChatViewModel CreatedConnectedViewModel(SignalRChatService chatService)
        {
            ChatViewModel viewModel = new ChatViewModel(chatService);

            chatService.Connect().ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                    viewModel.ErrorMessage = "Unable to connect to chat hub";
                }
            });

            return viewModel;
        }

        private void ChatService_MessageReceived(ChatMessage mess)
        {
            // Используем SynchronizationContext для добавления сообщения в UI-потоке
            _syncContext.Post(_ =>
            {
                Messages.Add(new ChatMessageViewModel(mess));
            }, null);
        }
    }
}
