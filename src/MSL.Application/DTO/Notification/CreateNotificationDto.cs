namespace MLS.Application.DTO.Notification
{
    public class CreateNotificationDto
    {
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
    }
}