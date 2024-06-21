namespace MLS.Application.DTO.Comment
{
    public class CreateCommentDto
    {
        public string Content { get; set; } = string.Empty;
        public string? Author { get; set; }
        public DateTime Timestamp { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
    }
}