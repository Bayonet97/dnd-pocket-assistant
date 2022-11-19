namespace DndPocketAssistant.Player.GUI.Lobby
{
    public class LobbyViewModel : ViewModelBase
    {
        public string ButtonText { get; set; } = "Works with VM";
        public ViewModelBase Parent { get; }
        public LobbyViewModel(ViewModelBase parent)
        {
            Parent = parent; 
        }
    }
}
