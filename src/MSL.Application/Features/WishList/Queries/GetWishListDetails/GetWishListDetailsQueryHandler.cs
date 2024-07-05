using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.WishList;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.WishList.Queries.GetWishListDetails;

public class GetWishListDetailsQueryHandler : IRequestHandler<GetWishListDetailsQuery, WishListDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IWishListRepository _wishListRepository;

    public GetWishListDetailsQueryHandler(IWishListRepository wishListRepository, IMapper mapper)
    {
        _wishListRepository = wishListRepository;
        _mapper = mapper;
    }

    public async Task<WishListDetailsDto> Handle(GetWishListDetailsQuery request, CancellationToken cancellationToken)
    {
        var wishList = await _wishListRepository.GetByIdAsync(request.Id);

        if (wishList is null)
            throw new NotFoundException(nameof(Domain.Entities.WishList), request.Id);

        var data = _mapper.Map<WishListDetailsDto>(wishList);

        return data;
    }
}