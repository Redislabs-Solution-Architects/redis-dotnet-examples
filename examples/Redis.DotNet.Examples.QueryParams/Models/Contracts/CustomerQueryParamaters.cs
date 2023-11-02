namespace Redis.DotNet.Examples.QueryParams.Models.Contracts
{
	public class CustomerQueryParamaters
	{

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string[] Publications { get; set; } = null!;

        public Address? Address { get; set; }
    }
}

