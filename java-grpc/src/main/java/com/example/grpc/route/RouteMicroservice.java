package com.example.grpc.route;

import io.grpc.Server;
import io.grpc.ServerBuilder;

import java.io.IOException;
import java.util.logging.Level;


public class RouteMicroservice
{
    public static void main( String[] args ) throws IOException, InterruptedException {

      Server server = ServerBuilder.forPort(6000)
      .addService(new RouteServiceImpl())
      .build();

    server.start();
    System.out.println("Server started on 6000");
    server.awaitTermination();
    }
}
