namespace dotnet_clean_arch.Domain.Events;

public class BlogItemCreatedEvent : BaseEvent
{
    public BlogItemCreatedEvent(BlogItem item)
    {
        Item = item;
    }

    public BlogItem Item { get; }
}