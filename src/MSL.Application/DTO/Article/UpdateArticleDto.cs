namespace MLS.Application.DTO.Article
{
    public class UpdateArticleDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int? UserId { get; set; }
    }
}