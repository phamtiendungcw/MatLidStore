using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductReview : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}