using dotnet_clean_arch.Application.Common.Mappings;
using dotnet_clean_arch.Domain.Entities;

namespace dotnet_clean_arch.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
