﻿using MediatR;
using MLS.Application.DTO.ShoppingCartItem;

namespace MLS.Application.Features.ShoppingCartItem.Commands.CreateShoppingCartItemCommand;

public class CreateShoppingCartItemCommand : IRequest<int>
{
    public CreateShoppingCartItemDto ShoppingCartItem { get; set; } = new();
}