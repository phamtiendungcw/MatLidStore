using MLS.Domain.Common;

namespace MLS.Domain.Entities;

public class Notification : BaseEntity
{
    public string Message { get; set; } = string.Empty; // Notification message content
    public DateTime Timestamp { get; set; } // Date and time notification was sent
    public bool IsRead { get; set; }

    public int UserId { get; set; } // Foreign key referencing User
    public User User { get; set; } = null!; // Navigation property for User
}