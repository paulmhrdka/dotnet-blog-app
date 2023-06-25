using AutoMapper;
using AutoMapper.QueryableExtensions;
using dotnet_clean_arch.Application.Common.Interfaces;
using dotnet_clean_arch.Application.Common.Mappings;
using dotnet_clean_arch.Application.Common.Models;
using MediatR;

namespace dotnet_clean_arch.Application.BlogItems.Queries.GetBlogItemsWithPagination;

public record GetBlogItemsWithPaginationQuery : IRequest<PaginatedList<BlogItemBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int Limit { get; init; } = 10;
}

public class GetBlogItemsWithPaginationQueryHandler : IRequestHandler<GetBlogItemsWithPaginationQuery, PaginatedList<BlogItemBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBlogItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<PaginatedList<BlogItemBriefDto>> Handle(GetBlogItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.BlogItems
            .OrderBy(b => b.Id)
            .ProjectTo<BlogItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.Limit);
    }
}