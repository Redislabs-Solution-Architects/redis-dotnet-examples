using System;
using Redis.OM.Modeling;

namespace Redis.DotNet.Examples.QueryParams.Models.Domain
{
    public class Address
    {
        [Indexed]public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }
        [Indexed]public string? City { get; set; }

        public Address(string addressLine1, string? city)
        {
            AddressLine1 = addressLine1;
            City = city;
        }
    }
}

