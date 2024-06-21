using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Notification
{
    public class NotificationDetailsDto : NotificationDto
    {
        public UserDto User { get; set; } = new();
    }
}