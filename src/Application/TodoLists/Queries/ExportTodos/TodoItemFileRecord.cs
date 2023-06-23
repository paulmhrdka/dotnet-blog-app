using dotnet_clean_arch.Application.Common.Mappings;
using dotnet_clean_arch.Domain.Entities;

namespace dotnet_clean_arch.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
