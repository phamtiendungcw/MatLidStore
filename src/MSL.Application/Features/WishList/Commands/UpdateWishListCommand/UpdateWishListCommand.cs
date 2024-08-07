﻿using MediatR;
using MLS.Application.DTO.WishList;

namespace MLS.Application.Features.WishList.Commands.UpdateWishListCommand;

public class UpdateWishListCommand : IRequest<Unit>
{
    public UpdateWishListDto WishList { get; set; } = null!;
}