using MLS.Application.DTO.Product;
using MLS.Application.DTO.Supplier;

namespace MLS.Application.DTO.Supply
{
    public class SupplyDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int SupplierId { get; set; }
        public SupplierDto Supplier { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}