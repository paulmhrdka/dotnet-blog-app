using dotnet_clean_arch.Application.Common.Mappings;
using dotnet_clean_arch.Domain.Entities;

namespace dotnet_clean_arch.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
