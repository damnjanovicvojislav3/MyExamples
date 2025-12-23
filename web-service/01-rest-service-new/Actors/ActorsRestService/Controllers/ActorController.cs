using Microsoft.AspNetCore.Mvc;

namespace ActorsRestService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public ActorController(ILogger<WeatherForecastController> logger)


        {
            _logger = logger;
        }

        [HttpGet(Name = "GetActor")]
        public IEnumerable<string> GetActors()
        {
            string[] result = new string[2];
            result[0] = "actor Bata Zivojinovic";
            result[1] = "actor John Wayne";
            return result;
             
        }

    }
}