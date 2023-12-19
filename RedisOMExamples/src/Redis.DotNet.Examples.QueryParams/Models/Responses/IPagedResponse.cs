namespace Redis.DotNet.Examples.QueryParams.Models.Responses
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

