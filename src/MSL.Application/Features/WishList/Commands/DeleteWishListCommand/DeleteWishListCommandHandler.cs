using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.WishList.Commands.DeleteWishListCommand;

public class DeleteWishListCommandHandler : IRequestHandler<DeleteWishListCommand, Unit>
{
    private readonly IWishListRepository _wishListRepository;

    public DeleteWishListCommandHandler(IWishListRepository wishListRepository)
    {
        _wishListRepository = wishListRepository;
    }

    public async Task<Unit> Handle(DeleteWishListCommand request, CancellationToken cancellationToken)
    {
        var wishListToDelete = await _wishListRepository.GetByIdAsync(request.Id);

        if (wishListToDelete is null)
            throw new NotFoundException(nameof(Domain.Entities.WishList), request.Id);

        await _wishListRepository.DeleteAsync(wishListToDelete);

        return Unit.Value;
    }
}