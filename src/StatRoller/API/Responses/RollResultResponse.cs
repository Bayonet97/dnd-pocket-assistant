namespace DndPocketAssistant.StatRoller.API.Responses
{
    public class RollResultResponse
    {
        public List<int> RollResults { get; private set; }
        public Guid PlayerId { get; private set; }
        public RollResultResponse(List<int> rollResults, Guid playerId)
        {
            RollResults = rollResults;
            PlayerId = playerId;
        }
    }
}
