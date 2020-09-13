using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace City.Services
{
    public class CityServiceImpl : CityServiceProto.CityServiceProtoBase
    {
        private readonly Dictionary<string, City> _cities;

        public CityServiceImpl()
        {
            _cities = new Dictionary<string, City>();
            City city1 = new City{Name = "Gdynia", State = "Pomerania", Population = 1234};
            City city2 = new City{Name = "Gdansk", State = "Pomerania", Population = 12345};
            City city3 = new City{Name = "Sopot", State = "Pomerania", Population = 123};
            _cities.Add(city1.Name.ToLower(), city1);
            _cities.Add(city2.Name.ToLower(), city2);
            _cities.Add(city3.Name.ToLower(), city3);
        }

        public override Task<City> FindByName(FindCityMessage request, ServerCallContext context)
        {
            return Task.FromResult(_cities[request.Name]);
        }

        public bool AddCity(City city)
        {
            _cities.Add(city.Name.ToLower(), city);
            return true;
        }
    }
}