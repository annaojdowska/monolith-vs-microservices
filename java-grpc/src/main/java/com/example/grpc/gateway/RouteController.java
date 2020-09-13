package com.example.grpc.gateway;

import com.example.grpc.city.CityOuterClass;
import com.example.grpc.route.Route;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class RouteController {

    @Autowired
    private final RouteChannelProvider routeChannelProvider;

    public RouteController(RouteChannelProvider routeChannelProvider) {
        this.routeChannelProvider = routeChannelProvider;
    }

    @RequestMapping(path = "/route", method = RequestMethod.GET)
    public List<String> getRoute() {
        Route.FindRouteMessage request =
                Route.FindRouteMessage.newBuilder().build();
        Route.ShortRoute response =  routeChannelProvider.stub.findShortestRoute(request);
        return response.getPointList();

    }
}
