namespace Redis.DotNet.Examples.QueryParams.Models.Contracts
{
	public class CustomerQueryParameters
	{

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string[]? Publications { get; set; }

        public Address? Address { get; set; }
    }
}

