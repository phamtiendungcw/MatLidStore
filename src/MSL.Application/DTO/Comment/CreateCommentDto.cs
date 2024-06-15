namespace MLS.Application.DTO.Comment
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
    }
}