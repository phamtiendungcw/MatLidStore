using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCart;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCart.Commands.CreateShoppingCartCommand;

public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, int>
{
    private readonly IAppLogger<CreateShoppingCartCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public CreateShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper, IAppLogger<CreateShoppingCartCommandHandler> logger)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateShoppingCartDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ShoppingCart, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}.", nameof(ShoppingCart), request.ShoppingCart);
            throw new BadRequestException("Invalid shopping cart!", validationResult);
        }

        var shoppingCartToCreate = _mapper.Map<Domain.Entities.ShoppingCart>(request.ShoppingCart);
        await _shoppingCartRepository.CreateAsync(shoppingCartToCreate);

        _logger.LogInformation("Shopping cart was created successfully!");
        return shoppingCartToCreate.Id;
    }
}