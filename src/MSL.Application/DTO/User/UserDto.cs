using MLS.Application.DTO.Comment;
using MLS.Application.DTO.Notification;
using MLS.Application.DTO.Order;
using MLS.Application.DTO.ProductReview;
using MLS.Application.DTO.WishList;

namespace MLS.Application.DTO.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
        public ICollection<ProductReviewDto> ProductReviews { get; set; }
        public ICollection<WishListDto> WishLists { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<NotificationDto> Notifications { get; set; }
    }
}