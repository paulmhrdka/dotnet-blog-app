using dotnet_clean_arch.Application.Common.Models;
using dotnet_clean_arch.Application.BlogItems.Commands.CreateBlogItem;
using dotnet_clean_arch.Application.BlogItems.Queries.GetBlogItemsWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_clean_arch.WebUI.Controllers;

[Authorize]
public class BlogItemsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<BlogItemBriefDto>>> GetBlogItemsWithPagination([FromQuery] GetBlogItemsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBlogItemCommand command)
    {
        return await Mediator.Send(command);
    }
}