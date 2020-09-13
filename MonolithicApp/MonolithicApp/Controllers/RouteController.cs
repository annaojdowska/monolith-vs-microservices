using Microsoft.AspNetCore.Mvc;
using IRouteService = MonolithicApp.Services.IRouteService;

namespace MonolithicApp.Controllers
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

        [HttpGet]
        public string[] GetRoute() => _routeService.FindShortestRoute();
    }
}