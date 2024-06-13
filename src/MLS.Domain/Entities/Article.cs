using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; } // Article title
        public string Content { get; set; } // Article content
        public string Author { get; set; } // Author name
        public DateTime PublicationDate { get; set; } // Date and time of publication

        public int UserId { get; set; } // Foreign key referencing User (author)
        public User AuthorUser { get; set; } // Navigation property for User

        public ICollection<Comment> Comments { get; set; } // One-to-Many relationship with Comment
    }
}