﻿namespace Redis.DotNet.Examples.QueryParams.Models.Requests
{
    public class Address
	{
		public string? AddressLine1 { get; set; }
        public string? City { get; set; }

        public Address(string addressLine1, string? city)
        {
            AddressLine1 = addressLine1;
            City = city;
        }
        public Address()
        {

        }
	}
}

