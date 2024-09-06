using MLS.Application.DTO.Comment;
using MLS.Application.DTO.Notification;
using MLS.Application.DTO.Order;
using MLS.Application.DTO.ProductReview;
using MLS.Application.DTO.WishList;

namespace MLS.Application.Models.Identity;

public class AuthResponse
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public List<OrderDto> Orders { get; set; } = new();
    public List<ProductReviewDto> ProductReviews { get; set; } = new();
    public List<WishListDto> WishLists { get; set; } = new();
    public List<CommentDto> Comments { get; set; } = new();
    public List<NotificationDto> Notifications { get; set; } = new();
}