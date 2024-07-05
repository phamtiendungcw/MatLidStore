using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCartItem;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCartItem.Commands.CreateShoppingCartItemCommand;

public class CreateShoppingCartItemCommandHandler : IRequestHandler<CreateShoppingCartItemCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public CreateShoppingCartItemCommandHandler(IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateShoppingCartItemCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateShoppingCartItemDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ShoppingCartItem, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Shopping Cart Item", validationResult);

        var shoppingCartItemToCreate = _mapper.Map<Domain.Entities.ShoppingCartItem>(request.ShoppingCartItem);
        await _shoppingCartItemRepository.CreateAsync(shoppingCartItemToCreate);

        return shoppingCartItemToCreate.Id;
    }
}