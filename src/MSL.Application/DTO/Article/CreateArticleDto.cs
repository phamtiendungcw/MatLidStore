using MLS.Application.DTO.Comment;

namespace MLS.Application.DTO.Article
{
    public class CreateArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public int AuthorId { get; set; }
        public List<CreateCommentDto> Comments { get; set; }
    }
}