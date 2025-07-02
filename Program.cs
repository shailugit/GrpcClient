using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer; // This comes from the auto-generated code



var httpHandler = new HttpClientHandler();
httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
using var channel = GrpcChannel.ForAddress("https://127.0.0.1/", new GrpcChannelOptions { HttpHandler = httpHandler });


//using var channel = GrpcChannel.ForAddress("https://myapimgrpc.azurewebsites.net/"); // my webApp as gRPC server
//using var channel = GrpcChannel.ForAddress("https://127.0.0.1/greet.Greeter/SayHello"); // my local docker                                                                                       
//using var channel = GrpcChannel.ForAddress("https://localhost:7239/greet.Greeter/SayHello"); // my local server code

var client = new Greeter.GreeterClient(channel);
Console.Write("Enter your name: ");
var name = Console.ReadLine();

var reply = await client.SayHelloAsync(new HelloRequest { Name = name });

Console.WriteLine("Greeting: " + reply.Message);

/*
var tasks = Enumerable.Range(0, 1).Select(async i =>
        {
            var reply = await client.SayHelloAsync(new HelloRequest { Name = $"User{i}" });
            Console.WriteLine($"Server Response {i}: {reply.Message}");
        });

        // Executes all tasks concurrently
        await Task.WhenAll(tasks);
*/
    
