using System;
using Redis.DotNet.Examples.QueryParams.Models.Contracts;
using Redis.DotNet.Examples.QueryParams.Models.Domain;

namespace Redis.DotNet.Examples.QueryParams.Services
{
	public interface ICustomerService
	{
		IQueryable<Customer> Search(CustomerQueryParameters parameters);
	}
}

