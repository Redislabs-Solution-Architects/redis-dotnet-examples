using Microsoft.Extensions.Options;
using Redis.OM.Contracts;
using Redis.OM;
using Redis.DotNet.Examples.QueryParams.Models.Domain;
using Redis.DotNet.Examples.QueryParams.Helpers;

namespace Redis.DotNet.Examples.QueryParams
{
	public class StartupService : IHostedService
	{
		private readonly IRedisConnectionProvider _provider;
        private readonly IOptions<DemoOptions> _settings;

		public StartupService(IRedisConnectionProvider provider, IOptions<DemoOptions> settings)
		{
			_provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
		}
		public async Task StartAsync(CancellationToken cancellationToken)
		{
			if (_settings.Value.DropIndex)
			{
                var customers = _provider.RedisCollection<Customer>();
                _provider.Connection.DropIndexAndAssociatedRecords(typeof(Customer));
				await _provider.Connection.CreateIndexAsync(typeof(Customer));
				await RedisHelper.SeedCustomers(customers);
			}

		}

		public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    }
}

