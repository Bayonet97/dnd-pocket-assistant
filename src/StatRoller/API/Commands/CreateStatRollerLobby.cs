namespace DndPocketAssistant.StatRoller.API.Commands
{
    public class CreateStatRollerLobby
    {
        public string DungeonMasterName { get; private set; }
        public StatRollerConfiguration.RollType ConfiguredRollType { get; private set; }
    }
}
