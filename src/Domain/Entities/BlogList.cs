namespace dotnet_clean_arch.Domain.Entities;

public class BlogList : BaseAuditableEntity
{
    public string? Title { get; set; }

    public IList<BlogItem> Items { get; private set; } = new List<BlogItem>();
}