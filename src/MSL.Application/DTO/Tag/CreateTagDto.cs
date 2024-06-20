using MLS.Application.DTO.Article;
using MLS.Application.DTO.ProductTag;

namespace MLS.Application.DTO.Tag
{
    public class CreateTagDto
    {
        public string Name { get; set; }
        public List<CreateProductTagDto> ProductTags { get; set; }
        public List<CreateArticleDto> Articles { get; set; }
    }
}