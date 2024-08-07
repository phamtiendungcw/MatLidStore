﻿using MediatR;
using MLS.Application.DTO.ShoppingCart;

namespace MLS.Application.Features.ShoppingCart.Commands.UpdateShoppingCartCommand;

public class UpdateShoppingCartCommand : IRequest<Unit>
{
    public UpdateShoppingCartDto ShoppingCart { get; set; } = null!;
}