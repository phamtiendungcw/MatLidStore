using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.WishList;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.WishList.Queries.GetWishListDetails;

public class GetWishListDetailsQueryHandler : IRequestHandler<GetWishListDetailsQuery, WishListDetailsDto>
{
    private readonly IAppLogger<GetWishListDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IWishListRepository _wishListRepository;

    public GetWishListDetailsQueryHandler(IWishListRepository wishListRepository, IMapper mapper, IAppLogger<GetWishListDetailsQueryHandler> logger)
    {
        _wishListRepository = wishListRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<WishListDetailsDto> Handle(GetWishListDetailsQuery request, CancellationToken cancellationToken)
    {
        var wishList = await _wishListRepository.GetByIdAsync(request.Id);

        if (wishList is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(WishList), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.WishList), request.Id);
        }

        var data = _mapper.Map<WishListDetailsDto>(wishList);

        _logger.LogInformation("Wish list details were retrieved successfully!");
        return data;
    }
}