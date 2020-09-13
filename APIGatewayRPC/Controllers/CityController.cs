using System.Threading.Tasks;
using City.Services;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace APIGatewayRPC.Controllers
{
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityServiceClientProvider _clientProvider;

        public CityController(CityServiceClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        [HttpGet("api/city")]
        public async Task<City.Services.City> GetCity(string name)
        {
            var message = new FindCityMessage() {Name = name };
            return await _clientProvider.CityService.FindByNameAsync(message);
        }

        [HttpGet("api/city/health")]
        public ActionResult HealthCheck()
        {
            return Ok();
        }
    }
}