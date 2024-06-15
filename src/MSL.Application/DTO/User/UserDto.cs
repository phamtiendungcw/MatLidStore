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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<AddressDto> Addresses { get; set; }
        public List<OrderDto> Orders { get; set; }
        public List<NotificationDto> Notifications { get; set; }
        public List<ArticleDto> Articles { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}