using System;
namespace Redis.DotNet.Examples.QueryParams.Models.Requests
{
    public class PagedRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

