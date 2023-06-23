using dotnet_clean_arch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet_clean_arch.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
