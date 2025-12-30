using Microsoft.AspNetCore.Mvc;
using ActorsRestService.Models;
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
        public IEnumerable<Actor> GetActors()
        {
            Actor[] result = new Actor[2];
            result[0] = new Actor()
            {
                ActorId =  1,
                FirstName = "Bata",
                LastName = "Zivojinovic",
                DateOfBirth = new DateTime(1933,06,05),
                CountryCode = "SR"
            };
            result[1] = new Actor()
            {
                ActorId = 13,
                FirstName = "Denzel",
                LastName = "Washington",
                DateOfBirth = new DateTime(1954,12,29),
                CountryCode = "US"
            };

            return result;
             
        }

    }
}