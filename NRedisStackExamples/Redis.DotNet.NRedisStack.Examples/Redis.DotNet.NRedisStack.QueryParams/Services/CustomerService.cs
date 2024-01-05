using NRedisStack;
using NRedisStack.RedisStackCommands;
using NRedisStack.Search;
using Redis.DotNet.NRedisStack.QueryParams.Extensions;
using Redis.DotNet.NRedisStack.QueryParams.Models.Domain;
using Redis.DotNet.NRedisStack.QueryParams.Models.Requests;
using StackExchange.Redis;

namespace Redis.DotNet.NRedisStack.QueryParams.Services
{
    public class CustomerService : ICustomerService
	{
        private ISearchCommands _searchCommands;
        private readonly IConnectionMultiplexer _redisConnection;
        private const string _customerIndex = "idx:customers";

        public CustomerService (IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection ?? throw new ArgumentNullException(nameof(redisConnection));
            _searchCommands = _redisConnection.GetDatabase().FT();
        }

        public IList<Customer> Search(GetCustomerQuery parameters)
        {
            string query = $"(@fullname:{parameters.FullName})" +
               $"{(!string.IsNullOrEmpty(parameters.Email) ? $" | (@email:{{{parameters.Email.Replace("@","\\@")}}})" : "")}" +
               $"{(!string.IsNullOrEmpty(parameters?.Address?.AddressLine1) ? $" | (@address:{parameters.Address.AddressLine1})" : "")}";


            return _searchCommands
                   .Search(_customerIndex,
                           new Query(query))
                   .ToJson()
                   .DeserializeJsonList<Customer>();
        }

    }
}

