using System.Text.Json;
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
            return _searchCommands
                   .Search(_customerIndex,
                           new Query($"@fullname:{parameters.FullName}|@email:{parameters.Email}|@address:{parameters.Address}"))
                   .ToJson()
                   .DeserializeJsonList<Customer>();
        }

    }
}

