package com.example.grpc.city;

import com.example.grpc.city.CityOuterClass;
import com.example.grpc.city.CityServiceProtoGrpc;
import io.grpc.stub.StreamObserver;

import java.util.HashMap;

public class CityServiceImpl extends CityServiceProtoGrpc.CityServiceProtoImplBase {

  private HashMap<String, CityOuterClass.City> cities;

  public CityServiceImpl() {
    CityOuterClass.City gdynia = CityOuterClass.City.newBuilder()
            .setName("Gdynia")
            .setPopulation(12345)
            .setState("Pomerania")
            .build();

    CityOuterClass.City gdansk = CityOuterClass.City.newBuilder()
            .setName("Gdansk")
            .setPopulation(123456)
            .setState("Pomerania")
            .build();

    CityOuterClass.City sopot = CityOuterClass.City.newBuilder()
            .setName("Sopot")
            .setPopulation(123)
            .setState("Pomerania")
            .build();

    cities = new HashMap<>();
    cities.put(gdansk.getName().toLowerCase(), gdansk);
    cities.put(gdynia.getName().toLowerCase(), gdynia);
    cities.put(sopot.getName().toLowerCase(), sopot);
  }

  @Override
  public void findByName(CityOuterClass.FindCityMessage request, StreamObserver<CityOuterClass.City> responseObserver) {

    String nameToLower = request.getName().toLowerCase();
    CityOuterClass.City response =  cities.get(nameToLower);

    responseObserver.onNext(response);

    responseObserver.onCompleted();
  }
}