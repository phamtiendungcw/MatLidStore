using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.WishList;

namespace MLS.Application.Features.WishList.Queries.GetAllWishLists;

public class GetAllWishListsQueryHandler : IRequestHandler<GetAllWishListsQuery, List<WishListDto>>
{
    private readonly IAppLogger<GetAllWishListsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IWishListRepository _wishListRepository;

    public GetAllWishListsQueryHandler(IWishListRepository wishListRepository, IMapper mapper, IAppLogger<GetAllWishListsQueryHandler> logger)
    {
        _wishListRepository = wishListRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<WishListDto>> Handle(GetAllWishListsQuery request, CancellationToken cancellationToken)
    {
        var wishLists = await _wishListRepository.GetAllAsync();
        var data = _mapper.Map<List<WishListDto>>(wishLists);

        _logger.LogInformation("Wish list were retrieved successfully!");
        return data;
    }
}