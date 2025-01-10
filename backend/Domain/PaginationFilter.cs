namespace Domain;

public class PaginationFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
}

public class PaginationFilter<T> : PaginationFilter
{
    public IEnumerable<T> Items { get; set; }
}

public class PaginationFilterDRO
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}