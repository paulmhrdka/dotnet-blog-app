namespace dotnet_clean_arch.Domain.Events;

public class BlogItemDeletedEvent : BaseEvent
{
    public BlogItemDeletedEvent(BlogItem item)
    {
        Item = item;
    }

    public BlogItem Item { get; }
}
