namespace Chat.WPF.ViewModels
{
    public class MainViewModel
    {
        public ChatViewModel ChatViewModel { get; }

        public MainViewModel(ChatViewModel chatViewModel)
        {
            ChatViewModel = chatViewModel;
        }
    }
}
