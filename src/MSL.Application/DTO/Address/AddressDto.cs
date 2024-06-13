namespace MLS.Application.DTO.Address
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public int UserId { get; set; } // User ID (for foreign key reference)
    }
}