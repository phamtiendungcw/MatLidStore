using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.WishList;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.WishList.Commands.UpdateWishListCommand;

public class UpdateWishListCommandHandler : IRequestHandler<UpdateWishListCommand, Unit>
{
    private readonly IAppLogger<UpdateWishListCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IWishListRepository _wishListRepository;

    public UpdateWishListCommandHandler(IWishListRepository wishListRepository, IMapper mapper, IAppLogger<UpdateWishListCommandHandler> logger)
    {
        _wishListRepository = wishListRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateWishListCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateWishListDtoValidator();
        var validationResult = await validator.ValidateAsync(request.WishList, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}.", nameof(WishList), request.WishList);
            throw new BadRequestException("Invalid wish list!", validationResult);
        }

        var wishListToUpdate = _mapper.Map<Domain.Entities.WishList>(request.WishList);
        await _wishListRepository.UpdateAsync(wishListToUpdate);

        _logger.LogInformation("Wish list were updated successfully!");
        return Unit.Value;
    }
}