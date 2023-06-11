using gRPC.Service;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:7162");
var greetClient = new Greeter.GreeterClient(channel);

HelloReply response = await greetClient.SayHelloAsync(new HelloRequest() { Name = "Mert" });
Console.WriteLine($"Response: {response.Message}");