package com.mgr.monolith;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import java.util.HashMap;

@RestController
public class CityController {

    public CityController() {
        cities = new HashMap<>();
        City city1 = new City("Gdynia", "Pomerania", 1234);
        City city2 = new City("Gdansk", "Pomerania", 12345);
        City city3 = new City("Sopot", "Pomerania", 123);
        cities.put(city1.getName().toLowerCase(), city1);
        cities.put(city2.getName().toLowerCase(), city2);
        cities.put(city3.getName().toLowerCase(), city3);
    }

    private HashMap<String, City> cities;

    @RequestMapping(path = "/city", method = RequestMethod.GET)
    public City getCity(@RequestParam("name") String name) {
        return findByName(name);
    }

    City findByName(String name){
        String nameToLower = name.toLowerCase();
        return cities.get(nameToLower);
    }
}
