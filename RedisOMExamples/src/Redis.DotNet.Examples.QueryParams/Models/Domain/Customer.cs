using Redis.OM.Modeling;

namespace Redis.DotNet.Examples.QueryParams.Models.Domain
{
    [Document(StorageType = StorageType.Json)]
    public class Customer
    {
        [RedisIdField][Indexed] public Guid Id { get; set; }

        [Indexed] public string FullName { get; set; } = null!;
        [Indexed] public string Email { get; set; } = null!;
        [Indexed(Sortable = true)] public int Age { get; set; }
        [Indexed] public string[] Publications { get; set; } = null!;

        [Indexed(CascadeDepth = 2)] public Address? Address { get; set; }
    }
}

