using MediatR;
using MLS.Application.DTO.Address;

namespace MLS.Application.Features.Address.Commands.CreateAddressCommand
{
    public class CreateAddressCommand : IRequest<int>
    {
        public AddressDto Address { get; set; }
    }
}