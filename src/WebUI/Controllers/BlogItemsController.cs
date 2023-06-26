using dotnet_clean_arch.Application.BlogItems.Commands.CreateBlogItem;
using dotnet_clean_arch.Application.BlogItems.Commands.UpdateBlogItem;
using dotnet_clean_arch.Application.BlogItems.Commands.DeleteBlogItem;
using dotnet_clean_arch.Application.BlogItems.Queries.GetBlogs;
using dotnet_clean_arch.Application.BlogItems.Queries.GetBlog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_clean_arch.WebUI.Controllers;

[Authorize]
public class BlogItemsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<BlogsVm>> GetAll()
    {
        return await Mediator.Send(new GetBlogsQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBlogItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogItemDto>> GetDetail(int id)
    {
        return await Mediator.Send(new GetBlogQuery { Id = id });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateBlogItemCommand command)
    {
        if (id != command.Id) return BadRequest();

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteBlogItemCommand(id));

        return NoContent();
    }
}