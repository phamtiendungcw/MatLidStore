﻿using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

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
            var shoppingCartToUpdate = _mapper.Map<Domain.Entities.ShoppingCart>(request.ShoppingCart);
            await _shoppingCartRepository.UpdateAsync(shoppingCartToUpdate);

            return Unit.Value;
        }
    }
}