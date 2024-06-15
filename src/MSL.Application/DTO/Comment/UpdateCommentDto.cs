namespace MLS.Application.DTO.Comment
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
    }
}