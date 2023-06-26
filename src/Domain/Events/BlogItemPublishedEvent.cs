namespace dotnet_clean_arch.Domain.Entities;

public class BlogItemPublishedEvent : BaseEvent
{
    public BlogItemPublishedEvent(BlogItem item)
    {
        Item = item;
    }

    public BlogItem Item { get; }
}