using System;
namespace Redis.DotNet.NRedisStack.QueryParams.Models.Response
{
	public interface IPagedResponse<T>
	{
        List<T> Items { get; }
        int Page { get; }
        int PageSize { get; }
        int TotalItems { get; }
        int TotalPages { get; }
    }
}

