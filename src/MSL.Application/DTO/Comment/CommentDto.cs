using MLS.Application.DTO.Article;
using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int ArticleId { get; set; }
        public ArticleDto Article { get; set; }
    }
}