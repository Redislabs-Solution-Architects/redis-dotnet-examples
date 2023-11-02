using Redis.DotNet.Examples.QueryParams.Models.Contracts;

namespace Redis.DotNet.Examples.QueryParams.Services
{
    public class CustomerService : ICustomerService
	{

        public Task Search(CustomerQueryParamaters parameters)
        {
            return Task.CompletedTask;
        }
    }
}

