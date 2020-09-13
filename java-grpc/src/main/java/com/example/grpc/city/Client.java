package com.example.grpc.city;

import com.example.grpc.city.CityOuterClass;
import com.example.grpc.city.CityServiceProtoGrpc;
import io.grpc.*;

public class Client {
    public static void main(String[] args) throws Exception {
        // Channel is the abstraction to connect to a service endpoint
        // Let's use plaintext communication because we don't have certs
        final ManagedChannel channel = ManagedChannelBuilder.forTarget("localhost:5000")
                .usePlaintext(true)
                .build();

        // It is up to the client to determine whether to block the call
        // Here we create a blocking stub, but an async stub,
        // or an async stub with Future are always possible.
        CityServiceProtoGrpc.CityServiceProtoBlockingStub stub = CityServiceProtoGrpc.newBlockingStub(channel);
        CityOuterClass.FindCityMessage request =
                CityOuterClass.FindCityMessage.newBuilder()
                        .setName("Ray")
                        .build();

        // Finally, make the call using the stub
        CityOuterClass.City response =
                stub.findByName(request);

        System.out.println(response);

        // A Channel should be shutdown before stopping the process.
        channel.shutdownNow();
    }
}
