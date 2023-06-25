namespace dotnet_clean_arch.Domain.Entities;
public class BlogItem : BaseAuditableEntity
{
    public string? Title { get; set; }

    public string? Content { get; set; }

    private bool _isPulbished;

    public bool IsPublished
    {
        get => _isPulbished;

        set
        {
            if (value == true && _isPulbished == false)
            {
                AddDomainEvent(new BlogItemPublishedEvent(this));
            }

            _isPulbished = value;
        }
    }

    public BlogList List { get; set; } = null!;
}