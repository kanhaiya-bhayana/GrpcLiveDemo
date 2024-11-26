using Grpc.Core;
using GrpcLiveServer;

namespace GrpcLiveServer.Services;
public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"{nameof(SayHello)} method called");
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
