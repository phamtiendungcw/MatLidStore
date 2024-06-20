using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.Supplier
{
    public class CreateSupplierDto
    {
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public List<CreateProductDto> Products { get; set; }
    }
}