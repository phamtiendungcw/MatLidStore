using MLS.Application.DTO.Article;
using MLS.Application.DTO.ProductTag;

namespace MLS.Application.DTO.Tag
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductTagDto> ProductTags { get; set; }
        public ICollection<ArticleDto> Articles { get; set; }
    }
}