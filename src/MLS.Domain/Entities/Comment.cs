﻿using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; } = string.Empty; // Comment content
        public string? Author { get; set; } // Comment author name (optional)
        public DateTime Timestamp { get; set; } // Date and time comment was posted

        public int ArticleId { get; set; } // Foreign key referencing Article (optional)
        public Article Article { get; set; } = null!; // Navigation property for Article

        public int UserId { get; set; } // Foreign key referencing User (optional)
        public User Commenter { get; set; } = null!; // Navigation property for User
    }
}