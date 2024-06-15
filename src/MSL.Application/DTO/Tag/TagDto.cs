using MLS.Application.DTO.ProductTag;

namespace MLS.Application.DTO.Tag
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductTagDto> ProductTags { get; set; }
    }
}