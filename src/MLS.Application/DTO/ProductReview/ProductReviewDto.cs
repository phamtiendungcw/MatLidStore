namespace MLS.Application.DTO.ProductReview;

public class ProductReviewDto
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; } = string.Empty;
    public DateTime ReviewDate { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
}