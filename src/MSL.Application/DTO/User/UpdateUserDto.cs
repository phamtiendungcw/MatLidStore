using MLS.Application.DTO.Comment;
using MLS.Application.DTO.Notification;
using MLS.Application.DTO.Order;
using MLS.Application.DTO.ProductReview;
using MLS.Application.DTO.WishList;

namespace MLS.Application.DTO.User
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<UpdateOrderDto> Orders { get; set; }
        public List<UpdateProductReviewDto> ProductReviews { get; set; }
        public List<UpdateWishListDto> WishLists { get; set; }
        public List<UpdateCommentDto> Comments { get; set; }
        public List<UpdateNotificationDto> Notifications { get; set; }
    }
}