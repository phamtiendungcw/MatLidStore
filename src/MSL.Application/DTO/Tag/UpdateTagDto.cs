using MLS.Application.DTO.Article;
using MLS.Application.DTO.ProductTag;

namespace MLS.Application.DTO.Tag
{
    public class UpdateTagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UpdateProductTagDto> ProductTags { get; set; }
        public List<UpdateArticleDto> Articles { get; set; }
    }
}