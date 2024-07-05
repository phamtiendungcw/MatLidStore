using MLS.Domain.Common;

namespace MLS.Domain.Entities;

public class Article : BaseEntity
{
    public string Title { get; set; } = string.Empty; // Article title
    public string Content { get; set; } = string.Empty; // Article content
    public string Author { get; set; } = string.Empty; // Author name
    public DateTime PublicationDate { get; set; } // Date and time of publication

    public int AuthorUserId { get; set; } // Foreign key referencing User (author)
    public User AuthorUser { get; set; } = null!; // Navigation property for User

    public List<Comment> Comments { get; set; } = new(); // One-to-Many relationship with Comment
}