package com.example.grpc.gateway;

import com.example.grpc.city.CityServiceProtoGrpc;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import org.springframework.stereotype.Service;

@Service
public class CityChannelProvider implements AutoCloseable{

    public ManagedChannel channel;
    public CityServiceProtoGrpc.CityServiceProtoBlockingStub stub;
    public CityChannelProvider() {
        channel = ManagedChannelBuilder.forTarget("localhost:5000")
                .usePlaintext(true)
                .build();

        // It is up to the client to determine whether to block the call
        // Here we create a blocking stub, but an async stub,
        // or an async stub with Future are always possible.
        stub = CityServiceProtoGrpc.newBlockingStub(channel);
    }


    @Override
    public void close() throws Exception {
        channel.shutdownNow();
    }
}
