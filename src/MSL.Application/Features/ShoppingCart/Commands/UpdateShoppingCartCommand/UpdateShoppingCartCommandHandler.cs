using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCart;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCart.Commands.UpdateShoppingCartCommand
{
    public class UpdateShoppingCartCommandHandler : IRequestHandler<UpdateShoppingCartCommand, Unit>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;

        public UpdateShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new UpdateShoppingCartDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ShoppingCart);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Shopping Cart", validationResult);

            var shoppingCartToUpdate = _mapper.Map<Domain.Entities.ShoppingCart>(request.ShoppingCart);
            await _shoppingCartRepository.UpdateAsync(shoppingCartToUpdate);

            return Unit.Value;
        }
    }
}