package com.example.grpc.city;

import io.grpc.Server;
import io.grpc.ServerBuilder;

import java.io.IOException;

public class CityMicroservice
{
    public static void main( String[] args ) throws IOException, InterruptedException {
        // Create a new server to listen on port 8080
      Server server = ServerBuilder.forPort(5000)
      .addService(new CityServiceImpl())
      .build();

    // Start the server
    server.start();

    // Server threads are running in the background.
    System.out.println("Server started on 5000");
    // Don't exit the main thread. Wait until server is terminated.
    server.awaitTermination();
    }
}
