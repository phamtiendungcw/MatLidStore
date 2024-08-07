﻿using MediatR;
using MLS.Application.DTO.ShoppingCart;

namespace MLS.Application.Features.ShoppingCart.Commands.CreateShoppingCartCommand;

public class CreateShoppingCartCommand : IRequest<int>
{
    public CreateShoppingCartDto ShoppingCart { get; set; } = new();
}