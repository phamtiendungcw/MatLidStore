using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.WishList.Commands.DeleteWishListCommand;

public class DeleteWishListCommandHandler : IRequestHandler<DeleteWishListCommand, Unit>
{
    private readonly IAppLogger<DeleteWishListCommandHandler> _logger;
    private readonly IWishListRepository _wishListRepository;

    public DeleteWishListCommandHandler(IWishListRepository wishListRepository, IAppLogger<DeleteWishListCommandHandler> logger)
    {
        _wishListRepository = wishListRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteWishListCommand request, CancellationToken cancellationToken)
    {
        var wishListToDelete = await _wishListRepository.GetByIdAsync(request.Id);

        if (wishListToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(WishList), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.WishList), request.Id);
        }

        await _wishListRepository.DeleteAsync(wishListToDelete);

        _logger.LogInformation("Wish list were deleted successfully!");
        return Unit.Value;
    }
}