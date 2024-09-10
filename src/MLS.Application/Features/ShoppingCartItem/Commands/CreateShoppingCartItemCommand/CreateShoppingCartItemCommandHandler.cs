using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCartItem;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCartItem.Commands.CreateShoppingCartItemCommand;

public class CreateShoppingCartItemCommandHandler : IRequestHandler<CreateShoppingCartItemCommand, int>
{
    private readonly IAppLogger<CreateShoppingCartItemCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public CreateShoppingCartItemCommandHandler(IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper, IAppLogger<CreateShoppingCartItemCommandHandler> logger)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateShoppingCartItemCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateShoppingCartItemDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ShoppingCartItem, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}.", nameof(ShoppingCartItem), request.ShoppingCartItem);
            throw new BadRequestException("Invalid shopping cart item!", validationResult);
        }

        var shoppingCartItemToCreate = _mapper.Map<Domain.Entities.ShoppingCartItem>(request.ShoppingCartItem);
        await _shoppingCartItemRepository.CreateAsync(shoppingCartItemToCreate);

        _logger.LogInformation("Shopping cart item was created successfully!");
        return shoppingCartItemToCreate.Id;
    }
}