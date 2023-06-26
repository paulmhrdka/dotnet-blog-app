using dotnet_clean_arch.Application.Common.Exceptions;
using dotnet_clean_arch.Application.Common.Interfaces;
using dotnet_clean_arch.Domain.Entities;
using dotnet_clean_arch.Domain.Events;
using MediatR;

namespace dotnet_clean_arch.Application.BlogItems.Commands.DeleteBlogItem;

public record DeleteBlogItemCommand(int Id) : IRequest;

public class DeleteBlogItemCommandHandler : IRequestHandler<DeleteBlogItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBlogItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteBlogItemCommand request, CancellationToken cancellationToken)
    {
        // Find
        var entity = await _context.BlogItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        // If not found, throw error not found
        if (entity == null)
        {
            throw new NotFoundException(nameof(BlogItem), request.Id);
        }

        // remove
        _context.BlogItems.Remove(entity);

        // Call Event
        entity.AddDomainEvent(new BlogItemDeletedEvent(entity));

        // Save Changes
        await _context.SaveChangesAsync(cancellationToken);

        // Return Value
        return Unit.Value;
    }
}
