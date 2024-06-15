using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Address
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}