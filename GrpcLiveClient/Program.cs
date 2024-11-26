using Grpc.Core;
using Grpc.Net.Client;
using GrpcLiveServer.Protos;

class GrpcClient
{
    static async Task Main(string[] args)
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7100");
        //var request = new HelloRequest { Name = "Tim" };
        //var client = new Greeter.GreeterClient(channel);
        //var response = await client.SayHelloAsync(request);


        var customerClient = new Customer.CustomerClient(channel);

        //var request = new CustomerLookupModel { UserId = 1 };

        //var response = await customerClient.GetCustomerInfoAsync(request);

        //Console.WriteLine(response);




        //Console.WriteLine(response.Message);

        Console.ReadLine();
    }
}