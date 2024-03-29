﻿using DndPocketAssistant.StatRoller.API.Rollers;

namespace DndPocketAssistant.StatRoller.API
{
    public static class StatRollerConfiguration
    {
        public enum RollType
        {
            FourSixDropLowest, // 4d6 drop lowest
            FourSixDropLowestPickOneSet, // 4d6 drop lowest, pick one of the rolled sets from the players
        }

        public static readonly IReadOnlyDictionary<RollType, Type> StatRollersByRollType = new Dictionary<RollType, Type>()
        {
            {RollType.FourSixDropLowest, typeof(FourSixDropLowestStatRoller) }
        };
    }
}
