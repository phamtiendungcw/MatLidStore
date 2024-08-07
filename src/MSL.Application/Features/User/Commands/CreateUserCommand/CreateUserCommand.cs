﻿using MediatR;
using MLS.Application.DTO.User;

namespace MLS.Application.Features.User.Commands.CreateUserCommand;

public class CreateUserCommand : IRequest<int>
{
    public CreateUserDto User { get; set; } = new();
}