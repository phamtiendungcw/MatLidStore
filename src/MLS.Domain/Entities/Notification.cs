using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Message { get; set; } // Notification message content
        public DateTime Timestamp { get; set; } // Date and time notification was sent

        public int UserId { get; set; } // Foreign key referencing User
        public User User { get; set; } // Navigation property for User
    }
}