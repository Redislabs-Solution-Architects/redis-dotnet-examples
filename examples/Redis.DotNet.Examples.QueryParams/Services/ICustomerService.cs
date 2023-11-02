using System;
using Redis.DotNet.Examples.QueryParams.Models.Contracts;

namespace Redis.DotNet.Examples.QueryParams.Services
{
	public interface ICustomerService
	{
		Task Search(CustomerQueryParamaters parameters);
	}
}

