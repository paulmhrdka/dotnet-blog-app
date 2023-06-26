using AutoMapper;
using AutoMapper.QueryableExtensions;
using dotnet_clean_arch.Application.Common.Interfaces;
using dotnet_clean_arch.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using dotnet_clean_arch.Application.BlogItems.Queries.GetBlogs;

namespace dotnet_clean_arch.Application.BlogItems.Queries.GetBlog;

[Authorize]
public record GetBlogQuery : IRequest<BlogItemDto>
{
    public int Id { get; init; }
}

public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, BlogItemDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBlogQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<BlogItemDto> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        return await _context.BlogItems
            .Where(i => i.Id == request.Id)
            .ProjectTo<BlogItemDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}