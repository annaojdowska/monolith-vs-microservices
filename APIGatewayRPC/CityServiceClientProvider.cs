using City.Services;
using Grpc.Net.Client;
using Route.Services;

namespace APIGatewayRPC
{
    public class CityServiceClientProvider
    {
        private CityServiceProto.CityServiceProtoClient _cityService;

        public CityServiceProto.CityServiceProtoClient CityService
        {
            get
            {
                if(_cityService == null)
                {
                    var channel = GrpcChannel.ForAddress("https://localhost:4001");
                    _cityService = new CityServiceProto.CityServiceProtoClient(channel);
                }
                return _cityService;
            }
        }
    }
    
    public class RouteServiceClientProvider
    {
        private RouteServiceProto.RouteServiceProtoClient _routeService;

        public RouteServiceProto.RouteServiceProtoClient RouteService
        {
            get
            {
                if (_routeService == null)
                {
                    var channel = GrpcChannel.ForAddress("https://localhost:3001");
                    _routeService = new RouteServiceProto.RouteServiceProtoClient(channel);
                }
                return _routeService;
            }
        }
    }
}