using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Chat.WPF.Services;
using Chat.WPF.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chat.WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //связь с хабом по url, адрес из json проекта Chat.SignalR, Properties
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chat")
                .Build();

            ChatViewModel chatViewModel = ChatViewModel.CreatedConnectedViewModel(new SignalRChatService(connection));
        }
    }
}
