using MLS.Application.DTO.Article;
using MLS.Application.DTO.ProductTag;

namespace MLS.Application.DTO.Tag;

public class TagDetailsDto : TagDto
{
    public List<ProductTagDto> ProductTags { get; set; } = new();
    public List<ArticleDto> Articles { get; set; } = new();
}