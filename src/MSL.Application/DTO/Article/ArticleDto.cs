using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Article
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public UserDto Author { get; set; }
    }
}