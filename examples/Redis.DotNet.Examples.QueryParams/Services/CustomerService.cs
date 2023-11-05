using Redis.DotNet.Examples.QueryParams.Models.Contracts;
using Redis.DotNet.Examples.QueryParams.Models.Domain;
using Redis.OM.Contracts;

namespace Redis.DotNet.Examples.QueryParams.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRedisConnectionProvider _connectionProvider; 
        public CustomerService(IRedisConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider ?? throw new ArgumentNullException();
        }

        public IQueryable<Customer> Search(CustomerQueryParameters parameters)
        {
            if(string.IsNullOrEmpty(parameters.FullName))
                return Enumerable.Empty<Customer>().AsQueryable();
            
            return _connectionProvider.RedisCollection<Customer>()
            .Where(x=>x.FullName.Contains(parameters.FullName));
        }
    }
}

