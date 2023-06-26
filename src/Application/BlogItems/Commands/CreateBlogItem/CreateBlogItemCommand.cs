using dotnet_clean_arch.Application.Common.Interfaces;
using dotnet_clean_arch.Domain.Entities;
using dotnet_clean_arch.Domain.Events;
using MediatR;

namespace dotnet_clean_arch.Application.BlogItems.Commands.CreateBlogItem;

// record -> reference type, value type (C# 10)
public record CreateBlogItemCommand : IRequest<int>
{
    public string? Title { get; init; }
    public string? Content { get; set; }
}


// Handler for Create a Blog Item
public class CreateBlogItemCommandHandler : IRequestHandler<CreateBlogItemCommand, int>
{
    // Interface
    private readonly IApplicationDbContext _context;

    // Constructor 
    public CreateBlogItemCommandHandler(IApplicationDbContext context) {
        _context = context;
    }

    // Method
    public async Task<int> Handle(CreateBlogItemCommand request, CancellationToken cancellationToken)
    {
        // define an Object Blog Item
        var entity = new BlogItem {
            Title = request.Title,
            Content = request.Content,
            IsPublished = false
        };

        // Call an Event Handler and pass the entity
        entity.AddDomainEvent(new BlogItemCreatedEvent(entity));

        // add entity to the Entities at IApplicationDbContext
        _context.BlogItems.Add(entity);

        // call a method asynchronously
        await _context.SaveChangesAsync(cancellationToken);
        
        // return an Id
        return entity.Id;
    }
}