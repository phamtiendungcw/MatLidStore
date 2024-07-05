using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCartItem;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCartItem.Commands.UpdateShoppingCartItemCommand;

public class UpdateShoppingCartItemCommandHandler : IRequestHandler<UpdateShoppingCartItemCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public UpdateShoppingCartItemCommandHandler(IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateShoppingCartItemCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateShoppingCartItemDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ShoppingCartItem, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Shopping Cart Item", validationResult);

        var shoppingCartItemToUpdate = _mapper.Map<Domain.Entities.ShoppingCartItem>(request.ShoppingCartItem);
        await _shoppingCartItemRepository.UpdateAsync(shoppingCartItemToUpdate);

        return Unit.Value;
    }
}