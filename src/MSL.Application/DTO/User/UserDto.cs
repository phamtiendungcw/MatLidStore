using MLS.Application.DTO.Address;
using MLS.Application.DTO.Article;
using MLS.Application.DTO.Comment;
using MLS.Application.DTO.Notification;
using MLS.Application.DTO.Order;

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
        public ICollection<AddressDto> Addresses { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
        public ICollection<NotificationDto> Notifications { get; set; }
        public ICollection<ArticleDto> Articles { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}