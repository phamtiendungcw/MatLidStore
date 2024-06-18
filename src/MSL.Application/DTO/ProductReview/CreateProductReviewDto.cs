namespace MLS.Application.DTO.ProductReview
{
    public class CreateProductReviewDto
    {
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}