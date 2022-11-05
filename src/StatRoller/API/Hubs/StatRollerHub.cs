using Microsoft.AspNetCore.SignalR;

namespace DndPocketAssistant.StatRoller.API.Hubs;

public class StatRollerHub : Hub
{
    private KeyValuePair<Guid, string> creatorNameById;
    private IDictionary<Guid, string> playerNamesById;

    public StatRollerHub()
    {
        playerNamesById = new Dictionary<Guid, string>();
    }

    public async Task CreateLobby(string creatorName)
    {
        if (creatorNameById.Key != Guid.Empty)
        {
            await Clients.Caller.SendAsync("ConnectionError", "A lobby already exists.");
        }

        var creatorId = Guid.NewGuid();

        creatorNameById = new(creatorId, creatorName);

        await Clients.Caller.SendAsync("LobbyCreated");
    }

    public async Task JoinLobby(string playerName)
    {
        var playerId = Guid.NewGuid();
        var isNewPlayer = playerNamesById.TryAdd(playerId, playerName);

        if (!isNewPlayer)
        {
            await Clients.Caller.SendAsync("ConnectionError", "You are already in the lobby.");
        }
    }

    public async Task EditConfiguration()
    {

    }

    public async Task RollStats(string user)
    {
        // TODO: Implement rolls.. should be depending on selected roll type by me with local console tool
        List<int> rollResults = null;
        await Clients.All.SendAsync("ReceiveStatRolls", user, rollResults);
    }
}