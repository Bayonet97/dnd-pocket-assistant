using DndPocketAssistant.StatRoller.API.Rollers;
using Microsoft.AspNetCore.Mvc;

namespace DndPocketAssistant.StatRoller.API.Controllers
{
    public class StatRollConfigurationController : Controller
    {
        private readonly IDictionary<StatRollConfiguration, Type> StatRollersByConfiguration = new Dictionary<StatRollConfiguration, Type>()
        { 
            {StatRollConfiguration.FourSixDropLowest, typeof(FourSixDropLowestStatRoller) }
        };

        // PUT: StatRollerConfigurationController/Update
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(StatRollConfiguration configuration)
        {
            try
            {
                if(StatRollersByConfiguration.TryGetValue(configuration, out var statRoller))
                {
                    var configuredStatRoller = (StatRoller?)Activator.CreateInstance(statRoller); 
                    // await.. set stat roller in application.
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Given configuration does not exist.");
                }
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}

// Open app -> Open Lobby -> Configure & let people join -> Start