using Microsoft.AspNetCore.SignalR;

namespace DndPocketAssistant.StatRoller.API.Hubs;

public class StatRollerHub : Hub
{
    public async Task RollStats(string user)
    {
        // TODO: Implement rolls.. should be depending on selected roll type by me with local console tool
        List<int> rollResults = null;
        await Clients.All.SendAsync("ReceiveRolls", user, rollResults);
    }
}