using MLS.Application.DTO.Comment;
using MLS.Application.DTO.Notification;
using MLS.Application.DTO.Order;
using MLS.Application.DTO.ProductReview;
using MLS.Application.DTO.WishList;

namespace MLS.Application.DTO.User
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<CreateOrderDto> Orders { get; set; }
        public List<CreateProductReviewDto> ProductReviews { get; set; }
        public List<CreateWishListDto> WishLists { get; set; }
        public List<CreateCommentDto> Comments { get; set; }
        public List<CreateNotificationDto> Notifications { get; set; }
    }
}