using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chat.WPF.Services;
using Chat.WPF.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chat.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //связь с хабом по url, адрес из json проекта Chat.SignalR, Properties
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chat")
                .Build();

            DataContext = ChatViewModel.CreatedConnectedViewModel(new SignalRChatService(connection));
        }
    }
}
