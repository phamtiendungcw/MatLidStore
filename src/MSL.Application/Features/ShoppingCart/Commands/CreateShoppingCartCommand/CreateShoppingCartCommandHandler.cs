using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCart;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCart.Commands.CreateShoppingCartCommand;

public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public CreateShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateShoppingCartDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ShoppingCart, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Shopping Cart", validationResult);

        var shoppingCartToCreate = _mapper.Map<Domain.Entities.ShoppingCart>(request.ShoppingCart);
        await _shoppingCartRepository.CreateAsync(shoppingCartToCreate);

        return shoppingCartToCreate.Id;
    }
}