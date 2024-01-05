using System.ComponentModel.DataAnnotations;

namespace Redis.DotNet.Examples.QueryParams.Models.Requests
{
	public class GetCustomerQuery : PagedRequest
	{
        [Required]
        public string FullName { get; set; }

        public string? Email { get; set; } = string.Empty;

        public string[]? Publications { get; set; }

        public Address? Address { get; set; }

    }
}