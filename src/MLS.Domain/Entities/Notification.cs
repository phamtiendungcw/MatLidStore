using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MLS.Domain.Entities;

public class Notification : BaseEntity
{
    [MaxLength(100)] public string Message { get; set; } = string.Empty; // Notification message content
    public DateTime Timestamp { get; set; } // Date and time notification was sent
    public bool IsRead { get; set; }

    public int UserId { get; set; } // Foreign key referencing AppUser
    public AppUser AppUser { get; set; } = null!; // Navigation property for AppUser
}