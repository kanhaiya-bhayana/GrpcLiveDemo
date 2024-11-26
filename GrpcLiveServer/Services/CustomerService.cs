using Grpc.Core;
using GrpcLiveServer.Protos;

namespace GrpcLiveServer.Services;

public class CustomerService
    (ILogger<CustomerService> log): Customer.CustomerBase
{
    public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
    {
        log.LogInformation($"{nameof(GetCustomerInfo)} method called");
        CustomerModel output = new CustomerModel();

        if (request.UserId == 1)
        {
            output.FirstName = "Jamie";
            output.LastName = "Smith";
        }
        else if (request.UserId == 2)
        {
            output.FirstName = "Jane";
            output.LastName = "Doe";
        }
        else
        {
            output.FirstName = "Greg";
            output.LastName = "Thomas";
        }

        return Task.FromResult(output);
    }

    public override async Task GetNewCustomerInfo(NewCustomerInfoModel request, 
        IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
    {

        List<CustomerModel> customers = new List<CustomerModel>
        {
            new CustomerModel
            {
                FirstName = "Tim",
                LastName = "Corey"
            },
            new CustomerModel
            {
                FirstName = "John",
                LastName = "Storm"
            },
            new CustomerModel
            {
                FirstName = "Mac",
                LastName = "Frost"
            },
            new CustomerModel
            {
                FirstName = "Paula",
                LastName = "Ware"
            },
            new CustomerModel
            {
                FirstName = "Erik",
                LastName = "Snow"
            },
        };

        foreach (var cust in customers)
        {
            await Task.Delay(1000);
            await responseStream.WriteAsync(cust);
        }
    }

}
