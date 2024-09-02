using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MLS.Domain.Entities;

public class Comment : BaseEntity
{
    [MaxLength(500)] public string Content { get; set; } = string.Empty; // Comment content
    [MaxLength(50)] public string Author { get; set; } = string.Empty; // Comment author name (optional)
    public DateTime Timestamp { get; set; } // Date and time comment was posted

    public int? ArticleId { get; set; } // Foreign key referencing Article (optional)
    public Article? Article { get; set; } // Navigation property for Article

    public int CommenterId { get; set; } // Foreign key referencing AppUser (optional)
    public AppUser Commenter { get; set; } = null!; // Navigation property for AppUser
}