using MLS.Application.DTO.Article;
using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Comment;

public class CommentDetailsDto : CommentDto
{
    public ArticleDto Article { get; set; } = new();
    public UserDto User { get; set; } = new();
}