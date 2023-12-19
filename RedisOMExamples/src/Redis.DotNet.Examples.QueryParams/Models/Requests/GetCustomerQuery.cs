namespace Redis.DotNet.Examples.QueryParams.Models.Requests
{
	public class GetCustomerQuery : PagedRequest
	{

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string[]? Publications { get; set; }

        public Address? Address { get; set; }

    }
}