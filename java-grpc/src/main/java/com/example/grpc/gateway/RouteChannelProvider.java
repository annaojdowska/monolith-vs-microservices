package com.example.grpc.gateway;

import com.example.grpc.route.RouteServiceProtoGrpc;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import org.springframework.stereotype.Service;

@Service
public class RouteChannelProvider implements AutoCloseable{

    public ManagedChannel channel;
    public RouteServiceProtoGrpc.RouteServiceProtoBlockingStub stub;
    public RouteChannelProvider() {
        channel = ManagedChannelBuilder.forTarget("localhost:6000")
                .usePlaintext(true)
                .build();

        // It is up to the client to determine whether to block the call
        // Here we create a blocking stub, but an async stub,
        // or an async stub with Future are always possible.
        stub = RouteServiceProtoGrpc.newBlockingStub(channel);
    }

    @Override
    public void close() throws Exception {
        channel.shutdownNow();
    }
}
