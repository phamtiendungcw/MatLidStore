using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}