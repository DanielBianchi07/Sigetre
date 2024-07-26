namespace Sigetre.Core.Requests;

public abstract class PagedNullableRequest : NullableRequest
{
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
}