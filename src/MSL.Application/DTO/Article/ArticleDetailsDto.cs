using MLS.Application.DTO.Comment;
using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Article
{
    public class ArticleDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public int AuthorId { get; set; }
        public UserDto AuthorUser { get; set; }
        public List<CommentDetailsDto> Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}