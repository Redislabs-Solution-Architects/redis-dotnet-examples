using System;
namespace Redis.DotNet.NRedisStack.QueryParams.Models.Domain
{
	public class Customer
	{
        public Guid Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string[]? Publications { get; set; }

        public Address? Address { get; set; }
    }
}

