namespace MLS.Application.DTO.Comment
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
        public int ArticleId { get; set; } // Article ID (for foreign key reference)
        public int UserId { get; set; } // User ID (for foreign key reference)
    }
}