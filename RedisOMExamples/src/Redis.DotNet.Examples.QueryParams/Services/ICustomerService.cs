using System;
using Redis.DotNet.Examples.QueryParams.Models.Requests;
using Redis.DotNet.Examples.QueryParams.Models.Domain;

namespace Redis.DotNet.Examples.QueryParams.Services
{
	public interface ICustomerService
	{
		IQueryable<Customer> Search(GetCustomerQuery parameters);
	}
}

