namespace MLS.Application.DTO.ProductReview
{
    public class ProductReviewDto
    {
        public int ProductReviewId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ProductId { get; set; } // Product ID (for foreign key reference)
        public int UserId { get; set; } // User ID (for foreign key reference)
    }
}