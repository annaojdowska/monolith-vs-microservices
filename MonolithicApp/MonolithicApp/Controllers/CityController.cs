using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using City = MonolithicApp.Model.City;
using ICityService = MonolithicApp.Services.ICityService;

namespace MonolithicApp.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;

        public CityController(ICityService cityService, ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger = logger;
        }

        [HttpGet("{name}")]
        public City Get(string name) => _cityService.FindByName(name);

        [HttpPost]
        public bool AddCity([FromBody] City city) => _cityService.AddCity(city);
    }
}