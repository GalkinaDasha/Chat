using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chat.WPF.Services
{
    public class SignalRChatService
    {
        // связь с хабом
        private readonly HubConnection _connection;

        // получение сообщений
        public event Action<ChatMessage> MessageReceived;

        public SignalRChatService(HubConnection connection)
        {
            _connection = connection;

            // слушаем метод ReceiveMessage, ждем объект ChatMessage
            _connection.On<ChatMessage>("ReceiveMessage", (mess) => MessageReceived?.Invoke(mess));
        }

        // соединение с сервером
        public async Task Connect()
        {
            await _connection.StartAsync();
        }

        // отвылка сообщений серверу
        // должно совпадать с методом из хаба SignalR
        public async Task SendMessage(ChatMessage mess)
        {
            await _connection.SendAsync("SendMessage", mess);
        }
    }
}
