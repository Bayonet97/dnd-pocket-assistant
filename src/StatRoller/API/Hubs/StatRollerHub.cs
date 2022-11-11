using DndPocketAssistant.StatRoller.API.Commands;
using DndPocketAssistant.StatRoller.API.Responses;
using DndPocketAssistant.StatRoller.API.Rollers;
using Microsoft.AspNetCore.SignalR;

namespace DndPocketAssistant.StatRoller.API.Hubs;
public class StatRollerHub : Hub
{
    private static KeyValuePair<Guid, string> dungeonMasterNameById;
    private static readonly IDictionary<Guid, string> playerNamesById = new Dictionary<Guid, string>();
    private static Rollers.StatRoller roller;

    public async Task CreateLobby(CreateStatRollerLobby createLobbyCommmand)
    {
        if (dungeonMasterNameById.Key != Guid.Empty)
        {
           throw new HubException("A lobby already exists.");
        }

        var dungeonMasterId = Guid.NewGuid();

        dungeonMasterNameById = new(dungeonMasterId, createLobbyCommmand.DungeonMasterName);

        if (StatRollerConfiguration.StatRollersByRollType.TryGetValue(createLobbyCommmand.ConfiguredRollType, out var statRoller))
        {
            roller = (Rollers.StatRoller)Activator.CreateInstance(statRoller)!;
        }

        await Clients.Caller.SendAsync("LobbyCreated");
    }

    public async Task JoinLobby(string playerName)
    {
        var playerId = Guid.NewGuid();
        var isNewPlayer = playerNamesById.TryAdd(playerId, playerName);

        if (!isNewPlayer)
        {
            throw new HubException("You are already in the lobby.");
        }

        await Clients.All.SendAsync("PlayerJoined", playerId, playerName);
    }

    public async Task RollStats(RollStats rollStatsCommand)
    {
        var rollResults = await roller.Roll();
        var response = new RollResultResponse(rollResults, rollStatsCommand.PlayerId);

        await Clients.All.SendAsync("ReceiveStatRolls", response);
    }
}