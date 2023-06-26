using AutoMapper;
using AutoMapper.QueryableExtensions;
using dotnet_clean_arch.Application.Common.Interfaces;
using dotnet_clean_arch.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dotnet_clean_arch.Application.BlogItems.Queries.GetBlogs;

[Authorize]
public record GetBlogsQuery : IRequest<BlogsVm>;

public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, BlogsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBlogsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<BlogsVm> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        return new BlogsVm
        {
            Items = await _context.BlogItems
                .AsNoTracking()
                .ProjectTo<BlogItemDto>(_mapper.ConfigurationProvider)
                .OrderBy(i => i.Id)
                .ToListAsync(cancellationToken)
        };
    }
}