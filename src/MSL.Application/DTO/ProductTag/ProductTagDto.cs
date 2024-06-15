using MLS.Application.DTO.Product;
using MLS.Application.DTO.Tag;

namespace MLS.Application.DTO.ProductTag
{
    public class ProductTagDto
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int TagId { get; set; }
        public TagDto Tag { get; set; }
    }
}