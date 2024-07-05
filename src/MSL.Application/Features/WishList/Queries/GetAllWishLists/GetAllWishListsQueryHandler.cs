using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.WishList;

namespace MLS.Application.Features.WishList.Queries.GetAllWishLists;

public class GetAllWishListsQueryHandler : IRequestHandler<GetAllWishListsQuery, List<WishListDto>>
{
    private readonly IMapper _mapper;
    private readonly IWishListRepository _wishListRepository;

    public GetAllWishListsQueryHandler(IWishListRepository wishListRepository, IMapper mapper)
    {
        _wishListRepository = wishListRepository;
        _mapper = mapper;
    }

    public async Task<List<WishListDto>> Handle(GetAllWishListsQuery request, CancellationToken cancellationToken)
    {
        var wishLists = await _wishListRepository.GetAllAsync();
        var data = _mapper.Map<List<WishListDto>>(wishLists);

        return data;
    }
}