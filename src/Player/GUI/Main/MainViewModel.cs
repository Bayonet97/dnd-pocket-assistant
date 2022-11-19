using DndPocketAssistant.Player.GUI.Lobby;

namespace DndPocketAssistant.Player.GUI.Main
{
    public class MainViewModel : ViewModelBase
    {
        public LobbyViewModel LobbyViewModel { get; }

        public MainViewModel()
        {
            LobbyViewModel = new LobbyViewModel(this);
        }

    }
}
