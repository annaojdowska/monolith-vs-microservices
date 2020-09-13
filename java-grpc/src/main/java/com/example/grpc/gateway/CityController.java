package com.example.grpc.gateway;

import com.example.grpc.city.CityOuterClass;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class CityController {

    @Autowired
    private final CityChannelProvider cityChannelProvider;

    public CityController(CityChannelProvider cityChannelProvider) {
        this.cityChannelProvider = cityChannelProvider;
    }

    @RequestMapping(path = "/city", method = RequestMethod.GET)
    public CityHttpResponse getCity(@RequestParam("name") String name) {
        CityOuterClass.FindCityMessage request =
                CityOuterClass.FindCityMessage.newBuilder()
                        .setName(name)
                        .build();
        CityOuterClass.City response =  cityChannelProvider.stub.findByName(request);
        return new CityHttpResponse(response.getName(), response.getState(), response.getPopulation());
    }
}
