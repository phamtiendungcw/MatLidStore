using MLS.Application.DTO.Address;

namespace MLS.Application.DTO.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<AddressDto> Addresses { get; set; }
    }
}