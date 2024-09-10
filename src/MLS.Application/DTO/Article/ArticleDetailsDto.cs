using MLS.Application.DTO.Comment;
using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Article;

public class ArticleDetailsDto : ArticleDto
{
    public UserDto AuthorUser { get; set; } = new();
    public List<CommentDto> Comments { get; set; } = new();
}