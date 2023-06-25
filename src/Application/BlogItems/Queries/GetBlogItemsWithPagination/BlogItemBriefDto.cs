using dotnet_clean_arch.Application.Common.Mappings;
using dotnet_clean_arch.Domain.Entities;

namespace dotnet_clean_arch.Application.BlogItems.Queries.GetBlogItemsWithPagination;

public class BlogItemBriefDto : IMapFrom<BlogItem>
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool IsPublished { get; set; }
}