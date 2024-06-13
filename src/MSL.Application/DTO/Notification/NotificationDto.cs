namespace MLS.Application.DTO.Notification
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; } // User ID (for foreign key reference)
    }
}