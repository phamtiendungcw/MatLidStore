using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.Supplier
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}