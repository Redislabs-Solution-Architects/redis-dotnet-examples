using Redis.DotNet.NRedisStack.QueryParams.Models.Requests;
using Redis.DotNet.NRedisStack.QueryParams.Models.Domain;

namespace Redis.DotNet.NRedisStack.QueryParams.Services
{
    public interface ICustomerService
	{
        public IList<Customer> Search(GetCustomerQuery parameters);
    }
}

