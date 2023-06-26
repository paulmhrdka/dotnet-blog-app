namespace dotnet_clean_arch.Application.BlogItems.Queries.GetBlogs;

public class BlogsVm
{
    public IList<BlogItemDto> Items { get; set; } = new List<BlogItemDto>();
}