using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.Supplier;

public class SupplierDetailsDto : SupplierDto
{
    public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
}