using dotnet_clean_arch.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace dotnet_clean_arch.Application.BlogItems.EventHandlers;

public class BlogItemCreatedEventHandler : INotificationHandler<BlogItemCreatedEvent>
{
    // Interface
    private readonly ILogger<BlogItemCreatedEventHandler> _logger;

    // Constructor
    public BlogItemCreatedEventHandler(ILogger<BlogItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    // Method
    public Task Handle(BlogItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("dotnet_clean_arch Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}