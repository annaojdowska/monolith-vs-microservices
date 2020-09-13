using System.Collections.Generic;

namespace CityService
{
    public interface ICityService
    {
        City FindByName(string name);
        bool AddCity(City city);
    }

    public class CityService : ICityService
    {
        private readonly Dictionary<string, City> _cities;

        public CityService()
        {
            _cities = new Dictionary<string, City>();
            City city1 = new City{Name = "Gdynia", State = "Pomerania", Population = 1234};
            City city2 = new City{Name = "Gdansk", State = "Pomerania", Population = 12345};
            City city3 = new City{Name = "Sopot", State = "Pomerania", Population = 123};
            _cities.Add(city1.Name.ToLower(), city1);
            _cities.Add(city2.Name.ToLower(), city2);
            _cities.Add(city3.Name.ToLower(), city3);
        }
        
        public City FindByName(string name)
        {
            return _cities[name];
        }

        public bool AddCity(City city)
        {
            _cities.Add(city.Name.ToLower(), city);
            return true;
        }
    }
}