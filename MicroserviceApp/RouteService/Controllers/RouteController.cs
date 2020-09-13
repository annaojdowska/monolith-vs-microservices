using Microsoft.AspNetCore.Mvc;
using RouteService.Services;

namespace RouteService.Controllers
{
    [ApiController]
    [Route("route")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        // [HttpGet]
        // public string[] GetRoute([FromBody] Point[] input) => _routeService.FindShortestRoute(input);
        
        [HttpGet]
        public string[] GetRoute() => _routeService.FindShortestRoute();
    }
}