using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Address
{
    public class AddressDetailsDto : AddressDto
    {
        public UserDto User { get; set; } = new();
    }
}