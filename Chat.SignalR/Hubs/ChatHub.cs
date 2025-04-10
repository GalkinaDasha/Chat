using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        // задача рассылка сообщений, выполняется асинхронно
        // используется ChatMessage из отдельного проекта,
        // т.к. и у клиента и у сервера должна быть одна структура данных,так удобнее ее использовать
        public async Task SendMessage(ChatMessage mess)
        {
            await Clients.All.SendAsync("ReceiveMessage", mess);
        }
    }
}
