using System;
namespace Redis.DotNet.Examples.QueryParams.Models.Responses
{
	public class PagedResponse<T> : IPagedResponse<T>
	{
        private PagedResponse(List<T> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalItems = totalCount;
        }

        public List<T> Items { get; }
        public int Page { get; }
        public int PageSize { get; }
        public int TotalItems { get; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        public bool HasNextPage => Page * PageSize < TotalItems;
        public bool HasPreviousPage => Page > 1;

        public static PagedResponse<T> Create(IEnumerable<T> query, int page, int pageSize)
        {
            var totalItems = query.Count();
            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new(items, page, pageSize, totalItems);
        }
    }
}

