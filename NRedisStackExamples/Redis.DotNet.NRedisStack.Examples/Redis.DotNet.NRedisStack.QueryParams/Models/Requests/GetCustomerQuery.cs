namespace Redis.DotNet.NRedisStack.QueryParams.Models.Requests
{
    public class GetCustomerQuery : PagedRequest
    {
        public string? FullName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string[]? Publications { get; set; }

        public Address? Address { get; set; }
    }
}

