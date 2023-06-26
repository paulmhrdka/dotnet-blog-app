using dotnet_clean_arch.Application.Common.Exceptions;
using dotnet_clean_arch.Application.Common.Interfaces;
using dotnet_clean_arch.Domain.Entities;
using MediatR;

namespace dotnet_clean_arch.Application.BlogItems.Commands.UpdateBlogItem;

public record UpdateBlogItemCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public string? Content { get; init; }

    public bool IsPublished { get; init; }
}

public class UpdateBlogItemCommandHandler : IRequestHandler<UpdateBlogItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBlogItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateBlogItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.BlogItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(BlogItem), request.Id);
        }

        entity.Title = request.Title;
        entity.Content = request.Content;
        entity.IsPublished = request.IsPublished;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
