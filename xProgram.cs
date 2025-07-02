using Grpc.Net.Client;
using GrpcServer;

//using var channel = GrpcChannel.ForAddress("http://localhost:5114");
using var channel = GrpcChannel.ForAddress("https://localhost:7239");
var client = new Greeter.GreeterClient(channel);

Console.Write("Enter your name: ");
var name = Console.ReadLine();

var reply = await client.SayHelloAsync(new HelloRequest { Name = name });

Console.WriteLine("Greeting: " + reply.Message);
Console.ReadLine();