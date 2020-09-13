using System.Linq;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Route.Services;

namespace APIGatewayRPC.Controllers
{
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly RouteServiceClientProvider _clientProvider;

        public RouteController(RouteServiceClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        [HttpGet("api/route")]
        public string[] FindRoute()
        {
            var request = new FindRouteMessage();
            var response = _clientProvider.RouteService.FindShortestRoute(request);
            return response.Point.ToArray();
        }

        [HttpGet("api/route/health")]
        public ActionResult HealthCheck()
        {
            return Ok();
        }
    }
}