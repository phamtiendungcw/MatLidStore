﻿using MediatR;

namespace MLS.Application.Features.Address.Commands.DeleteAddressCommand
{
    public class DeleteAddressCommand : IRequest<Unit>
    {
        public int AddressId { get; set; }
    }
}