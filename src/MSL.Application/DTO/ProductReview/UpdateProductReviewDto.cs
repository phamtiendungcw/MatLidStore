namespace MLS.Application.DTO.ProductReview;

public class UpdateProductReviewDto
{
    public int Id { get; set; }
    public int? Rating { get; set; }
    public string? ReviewText { get; set; }
    public DateTime? ReviewDate { get; set; }
    public int? ProductId { get; set; }
    public int? UserId { get; set; }
}